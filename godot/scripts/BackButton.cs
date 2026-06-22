using Godot;
using System;

public partial class BackButton : Button
{

	[Export] string doorTag;
	[Export] string sceneTag;
	[Export] string spawn_direction = "right";
	[Export] string prevSceneTag;
	public Marker2D spawn_point;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += OnButtonPressed;
		
	}

	private void OnButtonPressed()
	{
		
		// NavigationManager.Instance.goToDialogueScene(sceneTag, doorTag);
		NavigationManager.Instance.removeDialogueScene();
		// GD.Print("Show load prev scene when pressed");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
