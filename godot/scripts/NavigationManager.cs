using Godot;
using System;
using System.Net.Security;

public partial class NavigationManager : Node
{
	// singleton pattern - single instance of class that can be used in each of scenes to prevent restarting of items or counters
	public static NavigationManager Instance { get; private set; }

	// preload scenes
	private readonly PackedScene scene_cart1 = GD.Load<PackedScene>("res://scenes/TestScene.tscn");
	// private readonly PackedScene scene_cart2 = GD.Load<PackedScene>("res://scenes/NpcInteraction.tscn");

	private readonly PackedScene scene_cart2 = GD.Load<PackedScene>("res://scenes/TestScene2.tscn");
	private string spawn_door_tag;


	private readonly PackedScene scene_dialogue_collectables = GD.Load<PackedScene>("res://scenes/MCDialogue.tscn");
	private readonly PackedScene back_button = GD.Load<PackedScene>("res://scenes/MCDialogue.tscn");


	public void go_to_level(string level_tag, string destination_tag) {
		PackedScene scene_to_load;

		scene_to_load = level_tag switch {
			"TestScene" => scene_cart1,
			"TestScene2" => scene_cart2,
			"MCDialogue" => scene_dialogue_collectables,
			_ => null
		};

		if (scene_to_load != null) {
			spawn_door_tag = destination_tag;
			Node new_scene_instance = scene_to_load.Instantiate();
			Window root = GetTree().Root;
			Node current_scene = GetTree().CurrentScene;
			root.RemoveChild(current_scene);
			current_scene.QueueFree();
			root.AddChild(new_scene_instance);
			GetTree().CurrentScene = new_scene_instance;
		}
	}
	// Called when the node enters the scene tree for the first time.
	// To check if instance has been intitiated, if so return it
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	//public override void _Process(double delta)
	//{
	//}
}
