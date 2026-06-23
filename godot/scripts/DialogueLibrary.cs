using Godot;
using System;
using System.Collections.Generic;

public class DialogueLibrary
{
	private Dictionary<string, DialogueEvent> dialogueEvents = new Dictionary<string, DialogueEvent>();

	public DialogueLibrary()
	{

		DialogueBoxUI ui = DialogueBoxUI.Instance;

		dialogueEvents["testDialogue"] = new DialogueEvent(async () =>
		{

			ui.PhraseBegin();
			await ui.DisplayLine("first");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("second");
			await ui.DisplayLine("third");
			ui.ChangeTextSpeed(40);
			await ui.DisplayLine("fourth");
			await ui.PhraseEnd();

			ui.PhraseBegin();
			await ui.DisplayLine("lorem ");
			await ui.DisplayLine("ipsum ");
			await ui.DisplayLine("dolor ");
			await ui.DisplayLine("sit");
			await ui.PhraseEnd();


			ui.PhraseBegin();
			int choice = await ui.DisplayChoice("Yes", "No");

			if (choice == 0)
				await ui.DisplayLine("You picked yes.");
			else
				await ui.DisplayLine("You picked no.");

			await ui.PhraseEnd();
		});
	}

	public DialogueEvent GetEvent(string id)
	{
		return dialogueEvents[id];
	}
}
