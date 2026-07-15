using Godot;
using System;

public partial class MainMenu : Node2D
{
	[Export] public PackedScene startScene;
	[Export] public PackedScene creditScene;
	[Export] public Node currentScene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	void OnStartPressed(){
		Window root = GetTree().Root;
		Node newScene = startScene.Instantiate();

		root.AddChild(newScene);
		root.RemoveChild(currentScene);
	}
	
	void OnCreditsPressed(){
		Window root = GetTree().Root;
		Node newScene = creditScene.Instantiate();

		root.AddChild(newScene);
		root.RemoveChild(currentScene);
	}
	
	void OnQuitPressed(){
		GetTree().Quit();
	}
}
