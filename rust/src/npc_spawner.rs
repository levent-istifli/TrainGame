use std::ops::DerefMut;

use godot::classes::node::ProcessMode;
use godot::global::{randf, randf_range, randi_range};
use godot::prelude::*;
use godot::classes::{Input, Node2D, Timer};
use crate::npc::{NPC, NPCState};
use crate::seat::Seat;

const BOARD_DELAY_MIN: f64 = 0.2;
const BOARD_DELAY_MAX: f64 = 2.0;
const EXIT_DELAY_MIN: f64 = 0.2;
const EXIT_DELAY_MAX: f64 = 5.0;
const EXIT_CHANCE: f64 = 0.3;
const BOARDING_STOP_CHANCE: f64 = 0.1;

#[derive(GodotConvert, Var, Export, Default, Clone)]
#[godot(via = i64)]
pub enum NPCSpawnerState {
    #[default]
    Transit,
    Boarding,
    Exiting,
}

#[derive(GodotClass)]
#[class(base=Node2D, init)]
pub struct NPCSpawner {
    base: Base<Node2D>,
    #[export]
    spawn_points: Array<Gd<Node2D>>,
    #[export]
    seats: Array<Gd<Seat>>,
    #[export]
    #[init(val = 30)]
    num_npcs: i64,
    #[export]
    #[init(val = 540.0)]
    aisle_y_position: f32,
    #[export]
    npc_scene: OnEditor<Gd<PackedScene>>,
    #[export]
    boarding_timer: OnEditor<Gd<Timer>>,
    spawned_npcs: Vec<Gd<NPC>>,
    pub current_state: NPCSpawnerState,
}

#[godot_api]
impl NPCSpawner {
    #[func]
    fn on_npc_inactive(&mut self, mut signaller: Gd<NPC>) {
        signaller.bind_mut().current_state = NPCState::Inactive;
        let signaller = signaller.deref_mut();
        signaller.set_process_mode(ProcessMode::DISABLED);
        signaller.set_visible(false);
    }
    #[func]
    fn start_boarding(&mut self) {
        self.current_state = NPCSpawnerState::Boarding;
        self.boarding_timer.set_wait_time(randf_range(BOARD_DELAY_MIN, BOARD_DELAY_MAX));
        self.boarding_timer.start();
    }
    #[func]
    fn stop_boarding(&mut self) {
        self.current_state = NPCSpawnerState::Transit;
        self.boarding_timer.stop();
    }
    #[func]
    fn board_npc(&mut self) {
        let mut npc_to_board: Option<&mut Gd<NPC>> = None;
        for i in 0..self.spawned_npcs.len() {
            if self.spawned_npcs[i].bind().current_state == NPCState::Inactive {
                npc_to_board = self.spawned_npcs.get_mut(i);
                break
            }
        }
        if npc_to_board.is_none() {
            self.stop_boarding();
            return
        }
        let mut empty_seat_indices: Vec<usize> = Vec::with_capacity(self.seats.len());
        for i in 0..self.seats.len() {
            if !self.seats.get(i).unwrap().bind().occupied {
                empty_seat_indices.push(i)
            }
        }
        if empty_seat_indices.is_empty() {
            self.stop_boarding();
            return
        }
        let seat_index = empty_seat_indices[randi_range(0, (empty_seat_indices.len() - 1) as i64) as usize];
        self.seats.at(seat_index).bind_mut().occupied = true;
        let mut npc_to_board = npc_to_board.unwrap().bind_mut();
        npc_to_board.base_mut().set_position(self.spawn_points.pick_random().unwrap().get_position());
        npc_to_board.current_state = NPCState::Walking;
        npc_to_board.target_seat_index = seat_index as i64;
        npc_to_board.target_seat_position = self.seats.at(seat_index).get_position();
        npc_to_board.board_train(self.aisle_y_position);
        npc_to_board.base_mut().set_process_mode(ProcessMode::INHERIT);
        npc_to_board.base_mut().set_visible(true);
        if randf() > BOARDING_STOP_CHANCE {
            self.boarding_timer.set_wait_time(randf_range(BOARD_DELAY_MIN, BOARD_DELAY_MAX));
            self.boarding_timer.start();
        }
    }
    #[func]
    fn start_exiting(&mut self) {
        for i in 0..self.spawned_npcs.len() {
            if self.spawned_npcs[i].bind().current_state != NPCState::Sitting {
                continue
            }
            if randf() > EXIT_CHANCE {
                continue
            }
            let timer = self.base_mut().get_tree().create_timer_ex(randf_range(EXIT_DELAY_MIN, EXIT_DELAY_MAX)).process_in_physics(true).done();
            timer
                .signals()
                .timeout()
                .connect_other(&self.spawned_npcs[i], NPC::exit_train);
        }
    }
    #[func]
    fn exit_npc(&mut self, mut signaller: Gd<NPC>) {
        let mut signaller = signaller.bind_mut();
        signaller.current_state = NPCState::Exiting;
        self.seats.at(signaller.target_seat_index as usize).bind_mut().occupied = false;
        let target_exit = &self.spawn_points.at(randi_range(0, self.spawn_points.len() as i64 - 1) as usize);
        signaller.movement_targets.push(target_exit.get_position());
        let position = signaller.base().get_position();
        signaller.movement_targets.push(Vector2 { x: target_exit.get_position().x, y: self.aisle_y_position });
        let first_target = Vector2 { x: position.x, y: self.aisle_y_position };
        signaller.movement_targets.push(first_target);
        signaller.face_towards(first_target);
    }
}

use godot::classes::INode2D;

#[godot_api]
impl INode2D for NPCSpawner {
    fn ready(&mut self) {
        self.spawned_npcs.reserve(self.num_npcs as usize);
        for _ in 0..self.num_npcs {
            let mut new_npc = self.npc_scene.instantiate_as::<NPC>();
            new_npc
                .signals()
                .went_inactive()
                .connect_other(&self.to_gd(), Self::on_npc_inactive);
            new_npc
                .signals()
                .exiting_train()
                .connect_other(&self.to_gd(), Self::exit_npc);
            new_npc.set_z_index(1);
            self.base_mut().add_child(&new_npc);
            self.spawned_npcs.push(new_npc);
        }
    }

    fn physics_process(&mut self, _delta: f64) {
        let input = Input::singleton();
        if input.is_action_just_pressed("board") {
            self.start_boarding();
        }
        if input.is_action_just_pressed("exit") {
            self.start_exiting();
        }
    }
}