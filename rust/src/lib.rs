use godot::prelude::*;

mod main_scene;

struct TrainGame;

#[gdextension]
unsafe impl ExtensionLibrary for TrainGame {}