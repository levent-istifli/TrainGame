use godot::global::signf;
use godot::prelude::*;
use godot::classes::{CollisionShape2D, Sprite2D, CharacterBody2D, ShapeCast2D};

const WALK_SPEED: f32 = 300.0;

#[derive(GodotConvert, Var, Export, Default, Clone, PartialEq)]
#[godot(via = i64)]
pub enum NPCState {
    #[default]
    Inactive,
    Sitting,
    Walking,
    Exiting,
}

#[derive(GodotClass)]
#[class(base=CharacterBody2D, init)]
pub struct NPC {
    base: Base<CharacterBody2D>,
    #[export]
    sprite: OnEditor<Gd<Sprite2D>>,
    #[export]
    collision: OnEditor<Gd<CollisionShape2D>>,
    #[export]
    player_detector: OnEditor<Gd<ShapeCast2D>>,
    pub movement_targets: Vec<Vector2>,
    pub current_state: NPCState,
    pub target_seat_position: Vector2,
    pub target_seat_index: i64,
}

#[godot_api]
impl NPC {
    #[signal]
    pub fn went_inactive(signaller: Gd<NPC>);

    #[signal]
    pub fn exiting_train(signaller: Gd<NPC>);

    #[func]
    pub fn board_train(&mut self, aisle_y_position: f32) {
        self.movement_targets.push(self.target_seat_position);
        self.movement_targets.push(Vector2 { x: self.target_seat_position.x, y: aisle_y_position });
        self.movement_targets.push(Vector2 { x: self.base().get_position().x, y: aisle_y_position });
        self.face_towards(self.movement_targets[self.movement_targets.len() - 1]);
    }

    #[func]
    pub fn exit_train(&mut self) {
        let as_gd = self.to_gd();
        self.signals().exiting_train().emit(&(as_gd));
    }

    pub fn face_towards(&mut self, target: Vector2) {
        if self.base().get_position().x == target.x {
            if self.base().get_position().y < target.y {
                self.base_mut().set_velocity(Vector2 { x: 0.0, y: WALK_SPEED });
            }
            else {
                self.base_mut().set_velocity(Vector2 { x: 0.0, y: -WALK_SPEED });
            }
        }
        else {
            if self.base().get_position().x < target.x {
                self.base_mut().set_velocity(Vector2 { x: WALK_SPEED, y: 0.0 });
            }
            else {
                self.base_mut().set_velocity(Vector2 { x: -WALK_SPEED, y: 0.0 });
            }
        }
    }

    fn move_to_target(&mut self) -> bool {
        let collision_position = self.collision.get_global_position();
        let new_player_detector_position = collision_position + self.base().get_velocity() / 30.0;
        self.player_detector.set_global_position(new_player_detector_position);
        self.player_detector.force_shapecast_update();
        if self.player_detector.is_colliding() {
            return false;
        }
        let old_position = self.base().get_position();
        self.base_mut().move_and_slide();
        let new_position = self.base().get_position();
        let target;
        let pre;
        let post;
        if old_position.x == new_position.x {
            target = self.movement_targets[self.movement_targets.len() - 1].y;
            pre = old_position.y;
            post = new_position.y;
        }
        else {
            target = self.movement_targets[self.movement_targets.len() - 1].x;
            pre = old_position.x;
            post = new_position.x;
        }
        if signf((target - pre) as f64) != signf((target - post) as f64) {
            let new_position = self.movement_targets.pop().unwrap();
            self.base_mut().set_position(new_position);
            if self.movement_targets.is_empty() {
                return true;
            }
            else {
                self.face_towards(self.movement_targets[self.movement_targets.len() - 1]);
                return false;
            }
        }
        false
    }
}

use godot::classes::ICharacterBody2D;

#[godot_api]
impl ICharacterBody2D for NPC {
    fn ready(&mut self) {
        let as_gd = self.to_gd();
        self.signals().went_inactive().emit(&(as_gd));
    }

    fn physics_process(&mut self, _delta: f64) {
        match self.current_state {
            NPCState::Inactive => {},
            NPCState::Walking => {
                if self.move_to_target() {
                    self.current_state = NPCState::Sitting;
                }
            },
            NPCState::Exiting => {
                if self.move_to_target() {
                    let as_gd = self.to_gd();
                    self.signals().went_inactive().emit(&(as_gd));
                }
            }
            _ => {},
        }
    }
}