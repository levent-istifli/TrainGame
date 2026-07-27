using Godot;
using System;
using System.Collections.Generic;

public partial class DialogueTestUser : Node
{
	[Export] public string dialogueEventId = "OpeningDialogue";
	[Export] public bool playOnReady = true;

	public override async void _Ready()
	{
		if (!playOnReady) return;

		DialogueBoxUI ui = DialogueBoxUI.Instance;
		if (ui == null)
		{
			GD.PushError("Cannot start dialogue because DialogueBoxUI.Instance is missing.");
			return;
		}

		ui.ShowBox();

		try
		{
			DialogueLibrary lib = new();
			await lib.GetEvent(dialogueEventId).RunDialogue();
			Callable.From(() => NavigationManager.Instance.removeDialogueScene()).CallDeferred();
		}
		catch (KeyNotFoundException)
		{
			GD.PushError($"Dialogue event '{dialogueEventId}' was not found.");
		}
		catch (OperationCanceledException)
		{
		}
	}

	public override void _ExitTree()
	{
		DialogueBoxUI.Instance?.HideBox();
	}
}
