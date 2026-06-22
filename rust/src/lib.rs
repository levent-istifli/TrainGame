use godot::prelude::*;

mod npc;
mod npc_spawner;
mod seat;

struct TrainGame;

#[gdextension]
unsafe impl ExtensionLibrary for TrainGame {}