use godot::prelude::*;
use godot::classes::{Node, Node2D};
use crate::npc::{self, NPC};

#[derive(GodotClass)]
#[class(base=Node, init)]
pub struct NPCSpawner {
    base: Base<Node>,
    #[export]
    spawn_points: Array<Gd<Node2D>>,
    #[export]
    #[init(val = 30)]
    num_npcs: i64,
    spawned_npcs: Vec<Gd<NPC>>,
    npc_scene: Gd<PackedScene>,
}

impl NPCSpawner {
    fn on_npc_inactive(&mut self, signaller: Gd<NPC>) {

    }
}

use godot::classes::INode;

#[godot_api]
impl INode for NPCSpawner {
    fn ready(&mut self) {
        // TODO: Figure out how to preload
        self.npc_scene = load("uid://dabobsl1gguc8");
        self.spawned_npcs.reserve(self.num_npcs as usize);
        for _ in 0..self.num_npcs {
            let mut new_npc = self.npc_scene.instantiate_as::<NPC>();
            new_npc
                .signals()
                .went_inactive()
                .connect_other(&self.to_gd(), Self::on_npc_inactive);
            self.spawned_npcs.push(new_npc);
        }
    }
}