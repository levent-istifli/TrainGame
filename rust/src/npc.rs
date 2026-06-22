use godot::prelude::*;
use godot::classes::{CollisionShape2D, Sprite2D, CharacterBody2D};

#[derive(GodotConvert, Var, Export, Default, Clone, PartialEq)]
#[godot(via = i64)]
pub enum NPCState {
    #[default]
    Inactive,
    Sitting,
    Walking,
}

#[derive(GodotClass)]
#[class(base=CharacterBody2D, init)]
pub struct NPC {
    base: Base<CharacterBody2D>,
    #[export]
    sprite: OnEditor<Gd<Sprite2D>>,
    #[export]
    collision: OnEditor<Gd<CollisionShape2D>>,
    pub current_state: NPCState,
    pub target_seat_position: Vector2,
    pub target_seat_index: i64,
}

#[godot_api]
impl NPC {
    #[signal]
    pub fn went_inactive(signaller: Gd<NPC>);

    #[func]
    pub fn board_train(&mut self) {
        // self.base_mut().set_velocity(Vector2 { x: 0.0, y: -300.0 })
        let new_pos = self.target_seat_position;
        self.base_mut().set_position(new_pos);
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
                self.base_mut().move_and_slide();
            },
            _ => {},
        }
    }
}