using Godot;
using System;
using System.Threading.Tasks;

public partial class DialogueEvent
{
    private Func<Task> content;
    
    public DialogueEvent(Func<Task> content)
    {
        this.content = content;
    } 

    public Task RunDialogue()
    {
        return content();
    }
}
