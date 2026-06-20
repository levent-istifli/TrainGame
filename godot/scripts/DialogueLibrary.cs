using Godot;
using System;
using System.Collections.Generic;

public class DialogueLibrary
{
    private Dictionary<string, DialogueEvent> dialogueEvents = new Dictionary<string, DialogueEvent>();

    public DialogueLibrary()
    {
        dialogueEvents["testDialogue"] = new DialogueEvent(async () =>
        {
            DialogueBoxUI ui = DialogueBoxUI.Instance;
            await ui.DisplayText("Hello.");

            ui.ChangeTextSpeed(7);

            await ui.DisplayText("Here is a test question.");

            /*int choice = await ui.DisplayChoice("Yes", "No");

            if (choice == 0)
                await d.Display("You picked yes.");
            else
                await d.Display("You picked no.");*/
        });
    }

    public DialogueEvent GetEvent(string id)
    {
        return dialogueEvents[id];
    }
}
