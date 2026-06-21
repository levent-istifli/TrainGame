using Godot;
using System;

public partial class DialogueTestUser : Node
{
    public override void _Ready()
    {
        DialogueLibrary lib = new();
        lib.GetEvent("testDialogue").RunDialogue();
    }

}
