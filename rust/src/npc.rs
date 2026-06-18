use godot::prelude::*;
use godot::classes::{CollisionShape2D, Sprite2D, StaticBody2D};

#[derive(GodotConvert, Var, Export, Default, Clone)]
#[godot(via = i64)]
pub enum State {
    #[default]
    Inactive,
    Sitting,
    Walking,
}

#[derive(GodotClass)]
#[class(base=StaticBody2D, init)]
pub struct NPC {
    base: Base<StaticBody2D>,
    #[export]
    sprite: OnEditor<Gd<Sprite2D>>,
    #[export]
    collision: OnEditor<Gd<CollisionShape2D>>,
    pub current_state: State
}

#[godot_api]
impl NPC {
    #[signal]
    pub fn went_inactive(signaller: Gd<NPC>);
}

use godot::classes::IStaticBody2D;

#[godot_api]
impl IStaticBody2D for NPC {
    fn ready(&mut self) {
        let as_gd = self.to_gd();
        self.signals().went_inactive().emit(&(as_gd));
    }
}