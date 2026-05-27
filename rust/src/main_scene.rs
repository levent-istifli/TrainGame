use godot::prelude::*;
use godot::classes::Node;

#[derive(GodotClass)]
#[class(base=Node)]
pub struct MainScene {
    base: Base<Node>,
}

use godot::classes::INode;

#[godot_api]
impl INode for MainScene {
    fn init(base: Base<Node>) -> Self {
        godot_print!("Hello, world!"); // Prints to the Godot console
        Self {
            base
        }
    }
}
