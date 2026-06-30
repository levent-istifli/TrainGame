using Godot;
using System;

public partial class MainTestScene : Node
{
	// Called when the node enters the scene tree for the first time.
	[Export] PackedScene startingScene;
	[Export] PackedScene leftScene;
	[Export] PackedScene rightScene;
	[Export] CharacterBody2D player;
	public override void _Ready()
	{
		GD.Print(startingScene);
		Node startingSceneNode = startingScene.Instantiate();
		AddChild(startingSceneNode);

		Node leftSceneNode = leftScene.Instantiate();
		Node rightSceneNode = rightScene.Instantiate();
		Node2D leftSceneNode2D = leftSceneNode as Node2D;
		Node2D rightSceneNode2D = rightSceneNode as Node2D;

		if (leftSceneNode2D != null) {
			Vector2 positionChange = new Vector2(1920, 0);
			leftSceneNode2D.Position += positionChange;
		}

		if (rightSceneNode2D != null) {
			Vector2 positionChange = new Vector2(-1920, 0);
			rightSceneNode2D.Position -= positionChange;
		}

		AddChild(leftSceneNode);
		AddChild(rightSceneNode);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
