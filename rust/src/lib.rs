use godot::prelude::*;

mod npc;
mod npc_spawner;

struct TrainGame;

#[gdextension]
unsafe impl ExtensionLibrary for TrainGame {}