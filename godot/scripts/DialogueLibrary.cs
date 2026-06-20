using Godot;
using System;
using System.Collections.Generic;

public class DialogueLibrary
{
    private Dictionary<string, DialogueEvent> dialogueEvents = new Dictionary<string, DialogueEvent>();

    public DialogueLibrary()
    {
        
    }

    public DialogueEvent GetEvent(string id)
    {
        return dialogueEvents[id];
    }
}
