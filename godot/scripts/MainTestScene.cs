using Godot;
using System;

public partial class MainTestScene : Node
{
	// Called when the node enters the scene tree for the first time.
	[Export] PackedScene startingScene;
	[Export] PackedScene leftScene;
	[Export] PackedScene rightScene;
	[Export] CharacterBody2D player;
	[Export] PackedScene inventoryScene;
	[Export] PackedScene dialogueBoxScene;
	[Export] CanvasLayer uiLayer;

	public override void _Ready()
	{
		Node startingSceneNode = startingScene.Instantiate();
		AddChild(startingSceneNode);

		Node leftSceneNode = leftScene.Instantiate();
		Node rightSceneNode = rightScene.Instantiate();
		Node inventoryNode = inventoryScene.Instantiate();
		Node2D leftSceneNode2D = leftSceneNode as Node2D;
		Node2D rightSceneNode2D = rightSceneNode as Node2D;

		if (leftSceneNode2D != null) {
			Vector2 positionChange = new Vector2(1920, 0);
			leftSceneNode2D.Position += positionChange;
		}

		if (rightSceneNode2D != null) {
			Vector2 positionChange = new Vector2(-1920, 0);
			rightSceneNode2D.Position += positionChange;
		}

		AddChild(leftSceneNode);
		AddChild(rightSceneNode);
		GetUiParent().AddChild(inventoryNode);
		SpawnDialogueBox();
		Callable.From(StartOpeningDialogue).CallDeferred();

	}

	private void StartOpeningDialogue()
	{
		NavigationManager.Instance.loadDialogueScene("MCDialogue", "", "OpeningDialogue");
	}

	private void SpawnDialogueBox()
	{
		if (DialogueBoxUI.Instance != null)
		{
			DialogueBoxUI.Instance.HideBox();
			return;
		}

		if (dialogueBoxScene == null)
		{
			GD.PushError("MainScene is missing its dialogueBoxScene export.");
			return;
		}

		DialogueBoxUI dialogueBox = dialogueBoxScene.Instantiate<DialogueBoxUI>();
		GetUiParent().AddChild(dialogueBox);
		dialogueBox.HideBox();
	}

	private Node GetUiParent()
	{
		if (uiLayer == null)
		{
			GD.PushWarning("MainScene is missing its uiLayer export. UI will follow the world camera.");
			return this;
		}

		return uiLayer;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
