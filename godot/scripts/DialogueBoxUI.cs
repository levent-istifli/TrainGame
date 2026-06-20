using Godot;
using System;
using System.Threading.Tasks;

public partial class DialogueBoxUI : Node
{

	public static DialogueBoxUI Instance { get; private set; }

	[Export]
	public float charDuration = 0.1f;
	
	[Export]
	public Label textBox;

	[Export]
	public Timer charTimer;

	[Export]
	public Control nextIndicator;

	public string currString;
	public string nextString;

	private TaskCompletionSource<bool> waitNextLine;


	public override void _EnterTree()
	{
		if (Instance != null && Instance != this)
		{
			GD.PushWarning("Multiple DialogueBoxUI instances found. Replacing singleton instance.");
		}

		Instance = this;
	}

	public override void _ExitTree()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
	
	public void ClearBox()
	{
		textBox.Text = "";
	}

	int dialogueLine = 0;
	bool isTyping = false;

	public async Task DisplayText(string text)
	{
		ClearBox();

		currString = text;
		textIterator = 0;
		isTyping = true;
		skipped = false;
		nextIndicator.Visible = false;

		waitNextLine = new TaskCompletionSource<bool>();

		charTimer.Start();

		await waitNextLine.Task;
	}

	int textIterator = 0;
	private void OnCharTimeout()
	{
		if (textIterator < currString.Length)
		{
			textBox.Text += currString[textIterator];
			textIterator++;
			charTimer.Start();
		}
		else
		{
			isTyping = false;
			nextIndicator.Visible = true;
			charTimer.Stop();
		}
	}

	public void ChangeTextSpeed(float charsPerSecond)
	{
		charTimer.WaitTime = 1/charsPerSecond;
	}

	public override async void _Ready()
	{
		charTimer.WaitTime = charDuration;
		ClearBox();
	}

	bool skipped = false;
    public override void _Input(InputEvent @event)
    {

        if (@event.IsActionPressed("dialogueNext"))
		{
			if (isTyping)
			{
				charTimer.Stop();
				textBox.Text = currString;
				isTyping = false;
				nextIndicator.Visible = true;
			}
			else
			{
				waitNextLine?.TrySetResult(true);
			}
		}
    }

	public override void _Process(double delta)
	{
	}
}
