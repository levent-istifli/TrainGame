use godot::prelude::*;
use godot::classes::Node2D;

#[derive(GodotClass)]
#[class(base=Node2D, init)]
pub struct Seat {
    base: Base<Node2D>,
    pub occupied: bool,
}