use std::ops::DerefMut;

use godot::classes::node::ProcessMode;
use godot::prelude::*;
use godot::classes::{Node, Node2D};
use crate::npc::{State, NPC};

#[derive(GodotClass)]
#[class(base=Node, init)]
pub struct NPCSpawner {
    base: Base<Node>,
    #[export]
    spawn_points: Array<Gd<Node2D>>,
    #[export]
    #[init(val = 30)]
    num_npcs: i64,
    #[export]
    npc_scene: OnEditor<Gd<PackedScene>>,
    spawned_npcs: Vec<Gd<NPC>>,
}

impl NPCSpawner {
    fn on_npc_inactive(&mut self, mut signaller: Gd<NPC>) {
        signaller.bind_mut().current_state = State::Inactive;
        let signaller = signaller.deref_mut();
        signaller.set_process_mode(ProcessMode::DISABLED);
        signaller.set_visible(false);
    }
}

use godot::classes::INode;

#[godot_api]
impl INode for NPCSpawner {
    fn ready(&mut self) {
        self.spawned_npcs.reserve(self.num_npcs as usize);
        for _ in 0..self.num_npcs {
            let new_npc = self.npc_scene.instantiate_as::<NPC>();
            new_npc
                .signals()
                .went_inactive()
                .connect_other(&self.to_gd(), Self::on_npc_inactive);
            self.base_mut().add_child(&new_npc);
            self.spawned_npcs.push(new_npc);
        }
    }
}