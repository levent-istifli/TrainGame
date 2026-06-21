using Godot;
using System;

public partial class MainTestScene : Node2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] string scenePathToLoad = ("res://scenes/TestScene.tscn");
	public override void _Ready()
	{
		PackedScene startingScene = GD.Load<PackedScene>(scenePathToLoad);
		Node startingSceneNode = startingScene.Instantiate();
		AddChild(startingSceneNode);
		CharacterBody2D player = GetNode<CharacterBody2D>("Player");
		this.MoveChild(player, 1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
