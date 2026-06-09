using Godot;
using System;

public partial class DialogueBoxUI : Node
{

	[Export]
	public float charDuration = 0.1f;
	
	[Export]
	public Label textBox;

	[Export]
	public Timer charTimer;


	public string currString;
	public string nextString = "Lorem Ipsum Dolor Sit Amet";


	public void ClearBox()
	{
		textBox.Text = "";
	}


	public void DisplayNext()
	{
		currString = nextString;
		charTimer.Start();
	}


	int textIterator = 0;
	private void OnCharTimeout()
	{
		if (textIterator < currString.Length)
		{
			textBox.Text += currString[textIterator];
			charTimer.Start();
			textIterator++;
		}
		else 
		{
			textIterator = 0;
			charTimer.Stop();
		}
	}
	public override void _Ready()
	{
		charTimer.WaitTime = charDuration;
		ClearBox();
		DisplayNext();
	}


	public override void _Process(double delta)
	{
	}
}
