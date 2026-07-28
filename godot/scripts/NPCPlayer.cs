using Godot;
using System;

public partial class NPCPlayer : Area2D
{
	[Export] public string firstDialogueEventId;
	[Export] public string repeatDialogueEventId;
	[Export] public string[] flagsToCheck = Array.Empty<string>();
	[Export] public string[] flagDialogueEventIds = Array.Empty<string>();
	private bool hasInteracted = false;
	[Export] public Area2D area;
	[Export] public Sprite2D NpcSprite;
	[Export] string sceneTag;
	[Export] string destination_door_tag;
	[Export] string currentSceneTag;
	[Export] string spawn_direction = "right";
	[Export] public string name;

	public Marker2D spawn_point;

	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (NavigationManager.Instance.IsDialogueSceneOpen()) return;

		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left)
			{
				doEvent();
			}
		}	
	}

	public void doEvent()
	{
		string eventToPlay = hasInteracted
		? repeatDialogueEventId
		: firstDialogueEventId;

		if (hasInteracted)
		{
			int flagCount = Math.Min(flagsToCheck.Length, flagDialogueEventIds.Length);
			for (int i = flagCount - 1; i >= 0; i--)
			{
				if (!string.IsNullOrEmpty(flagsToCheck[i])
				&& NavigationManager.Instance.HasStoryFlag(flagsToCheck[i])
				&& !string.IsNullOrEmpty(flagDialogueEventIds[i]))
				{
					eventToPlay = flagDialogueEventIds[i];
					break;
				}
			}
		}

		hasInteracted = true;
		DialogueBoxUI.Instance.animationBaseName = name;
		NavigationManager.Instance.loadDialogueScene(sceneTag, "", eventToPlay);
		
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
