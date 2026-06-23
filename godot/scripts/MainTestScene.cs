using Godot;
using System;

public partial class MainTestScene : Node
{
	// Called when the node enters the scene tree for the first time.
	[Export] PackedScene startingScene;
	[Export] CharacterBody2D player;
	public override void _Ready()
	{
		GD.Print(startingScene);
		Node startingSceneNode = startingScene.Instantiate();
		AddChild(startingSceneNode);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
