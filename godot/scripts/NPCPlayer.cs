using Godot;
using System;

public partial class NPCPlayer : Area2D
{
	[Export] public Area2D area;
	[Export] public Sprite2D NpcSprite;

	[Export] string sceneTag;
	[Export] string destination_door_tag;
	[Export] string currentSceneTag;
	[Export] string spawn_direction = "right";

	public Marker2D spawn_point;

	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left)
			{
				NavigationManager.Instance.loadDialogueScene(sceneTag, "");
			}
		}	
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		if (NpcSprite == null)
		{
			GD.PrintErr($"NpcSprite node is null ${Name}");
			return;
		}

		MouseEntered += HighlightSprite;
		MouseExited += RevertHighlightedSprite;

		// spawn_point = GetNode<Marker2D>("Spawn");
	}

	public void HighlightSprite()
	{
		NpcSprite.Modulate = new Color("#eaf691");	
	}

	public void RevertHighlightedSprite()
	{
		NpcSprite.Modulate = new Color("#ffffff");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
