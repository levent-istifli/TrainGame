using Godot;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GodotStringIntercept;

public partial class DialogueBoxUI : Node2D
{

	public static DialogueBoxUI Instance { get; private set; }

	[Export] public float charDuration = 0.2f;
	[Export] public Label textBox;
    [Export] public Label speakerName;
	[Export] public Label option1TextBox;
	[Export] public Label option2TextBox;
	[Export] public Control option1Indicator;
	[Export] public Control option2Indicator;
	[Export] public Timer charTimer;
	[Export] public Control nextIndicator;
    [Export] public AnimatedSprite2D background;

	public string currLine;
	public string currString;
	public string nextString;
	bool skipped = false;
	bool phraseFinished = false;
    bool willStartTrain = false;
    bool willStopTrain = false;

	private TaskCompletionSource<bool> waitPhraseEnd;
	private TaskCompletionSource<bool> waitNextLine;
	private TaskCompletionSource<int> waitQuestion;
	private ulong inputEnabledAtTicks = 0;
	bool isChoosing = false;
	int selectedOption = 0;

    public string animationBaseName;
	
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

	public void ShowBox()
	{
		ResetDialogueState(false);
		Visible = true;
		ProcessMode = ProcessModeEnum.Inherit;
		inputEnabledAtTicks = Time.GetTicksMsec() + 150;
	}

	public void HideBox()
	{
		ResetDialogueState(true);
        if(willStartTrain)
        {
            NavigationManager.Instance.startTrain();
            willStartTrain = false;
        }
        if(willStopTrain)
        {
            NavigationManager.Instance.stopTrain();
            willStopTrain = false;
        }
		Visible = false;
		ProcessMode = ProcessModeEnum.Disabled;
		inputEnabledAtTicks = 0;
        animationBaseName = "";
	}

	private void ResetDialogueState(bool cancelWaits)
	{
		charTimer?.Stop();

		currLine = "";
		currString = "";
		nextString = "";
		textIterator = 0;
		skipped = false;
		phraseFinished = false;
		isTyping = false;
		isChoosing = false;
		selectedOption = -1;

		if (nextIndicator != null) nextIndicator.Visible = false;
		if (option1TextBox != null) option1TextBox.Visible = false;
		if (option2TextBox != null) option2TextBox.Visible = false;
		if (option1Indicator != null) option1Indicator.Visible = false;
		if (option2Indicator != null) option2Indicator.Visible = false;
		if (textBox != null) textBox.Text = "";

		if (!cancelWaits) return;

		waitPhraseEnd?.TrySetCanceled();
		waitNextLine?.TrySetCanceled();
		waitQuestion?.TrySetCanceled();
		waitPhraseEnd = null;
		waitNextLine = null;
		waitQuestion = null;
	}

	int dialogueLine = 0;
	bool isTyping = false;

	//Don't use this for now
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

	public async Task DisplayLine(string text)
	{
		currLine = text;
		currString += text;
		
		if (skipped) return;

		textIterator = 0;
		isTyping = true;
		nextIndicator.Visible = false;
        if(speakerName.Text == "Nozomi")
        {
            background.Play(new StringName(animationBaseName + "MCTalking"));
        }
        else if(speakerName.Text == "Mother" || speakerName.Text == "Kohana" || speakerName.Text == "Hana" || speakerName.Text == "Hotaru" || speakerName.Text == "Yoru")
        {
            background.Play(new StringName(animationBaseName + "Talking"));
        }

		waitNextLine = new TaskCompletionSource<bool>();

		charTimer.Stop();
		charTimer.Start();

		await waitNextLine.Task;
	}


	public void PhraseBegin()
	{
		charTimer.Stop();
		currLine = "";
		currString = "";
		textIterator = 0;

		isTyping = false;
		skipped = false;

		nextIndicator.Visible = false;
		ClearBox();
	}

	public async Task PhraseEnd()
	{
		skipped = false;
		isTyping = false;
		charTimer.Stop();
		
		nextIndicator.Visible = true;
		textBox.Text = currString;

        background.Play(new StringName(animationBaseName + "Idle"));

		phraseFinished = true;
		waitPhraseEnd = new TaskCompletionSource<bool>();

		await waitPhraseEnd.Task;
	}

	int textIterator = 0;
	private void OnCharTimeout()
	{
		if (!isTyping || skipped) return;

		if (textIterator < currLine.Length)
		{
			textBox.Text += currLine[textIterator];
			textIterator++;
			charTimer.Start();
		}
		else
		{
			isTyping = false;
			charTimer.Stop();
			waitNextLine?.TrySetResult(true);
		}
	}

	public async Task<int> DisplayChoice(string option1, string option2, string option3 = "", string option4 = "")
	{
		ClearBox();

		nextIndicator.Visible = false;

		option1TextBox.Text = option1;
		option2TextBox.Text = option2;

		option1TextBox.Visible = true;
		option2TextBox.Visible = true;
		option1Indicator.Visible = false;
		option2Indicator.Visible = false;

		selectedOption = -1;

		isChoosing = true;

		waitQuestion = new TaskCompletionSource<int>();

		int result = await waitQuestion.Task;

		selectedOption = -1;

		isChoosing = false;
		
		option1Indicator.Visible = false;
		option2Indicator.Visible = false;

		option1TextBox.Visible = false;
		option2TextBox.Visible = false;

		return result;
	}

	public void ChangeTextSpeed(float charsPerSecond)
	{
		charTimer.WaitTime = 1/(charsPerSecond * 6);
	}

	//Helpers for question mouse input
	private void SelectOption(int option)
	{
		selectedOption = option;

		option1Indicator.Visible = option == 0;
		option2Indicator.Visible = option == 1;
	}

	private void DeselectOption(int option)
	{
		if (selectedOption == option) selectedOption = -1;

		if (option == 0) option1Indicator.Visible = false;
		else if (option == 1) option2Indicator.Visible = false;
	}

    public void SetSpeaker(string speaker)
    {
        speakerName.Text = speaker;
    }

    public void StartTrain()
    {
        willStartTrain = true;
    }

    public void StopTrain()
    {
        willStopTrain = true;
    }

    public void GoToStation(int station)
    {
        NavigationManager.Instance.currentStation = station;
    }

    public void BoardNPC(string name)
    {
        NavigationManager.Instance.boardQueue.Add(name);
    }

    public void ExitNPC(string name)
    {
        NavigationManager.Instance.exitQueue.Add(name);
    }

	private void OnOption1MouseEntered()
	{
		SelectOption(0);
	}

	private void OnOption1MouseExited()
	{
		DeselectOption(0);
	}

	private void OnOption2MouseEntered()
	{
		SelectOption(1);
	}

	private void OnOption2MouseExited()
	{
		DeselectOption(1);
	}
	private void ConfirmOption(int option)
	{
		if (!isChoosing) return;

		waitQuestion?.TrySetResult(option);
	}

	public override void _Ready()
	{
		charTimer.WaitTime = charDuration;
		ClearBox();
	}

	public override void _Input(InputEvent @event)
	{
		if (!Visible) return;
		if (Time.GetTicksMsec() < inputEnabledAtTicks) return;

		if (@event.IsActionPressed("dialogueNext".AsStringName()))
		{

			if (isChoosing)
			{
				if (selectedOption != -1)
				{
					ConfirmOption(selectedOption);
					return;
				}
			}

			if (isTyping)
			{	
				skipped = true;
				isTyping = false;
				charTimer.Stop();
				waitNextLine?.TrySetResult(true);
			} else
			{
				if (phraseFinished)
				{
					phraseFinished = false;
					nextIndicator.Visible = false;
					waitPhraseEnd?.TrySetResult(true);
				}
			}
		}
	}
}
