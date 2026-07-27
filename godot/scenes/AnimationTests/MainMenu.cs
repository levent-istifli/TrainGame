using Godot;
using System;

public partial class MainMenu : Node2D
{
	[Export] public AudioStreamPlayer button;
	[Export] public AudioStreamPlayer doors;

	[Export] public PackedScene startScene;
	[Export] public PackedScene creditScene;
	[Export] public Node currentScene;
	[Export] public Texture2D trainBackground;
	[Export] public float bckgdSpeed = 100f;

	private Sprite2D trainOne;
	private Sprite2D trainTwo;
	private float trainWidth = 1920;

	private enum MenuState { Moving, Stopping, DoorsOpening, FadingOut, EndScene }
	private MenuState state = MenuState.Moving;
	[Export] public Sprite2D leftDoor;
	[Export] public Sprite2D rightDoor;
	[Export] public Node2D stoppedTrainScene;
	[Export] public float doorSlidingDistance = 40f;
	[Export] public float stopDuration = 1.2f;
	[Export] public float stopX = 960f;

	[Export] public ColorRect darkness;
	[Export] public Control buttons;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		darkness.Modulate = new Color(0, 0, 0, 0);
		stoppedTrainScene.Visible = false;

		trainOne = new Sprite2D
		{
			Texture = trainBackground,
			Centered = false,
			Position = new Vector2(0,0)
		};
		trainTwo = new Sprite2D
		{
			Texture = trainBackground,
			Centered = false,
			Position = new Vector2(trainWidth, 0)
		};

		trainOne.ZIndex = 1;
		trainTwo.ZIndex = 1;

		AddChild(trainOne);
		AddChild(trainTwo);
		MoveChild(trainOne, 0);
		//MoveChild(trainTwo, 1);
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (state == MenuState.Moving) { 
			float move = (float)(bckgdSpeed * delta);
			trainOne.Position += new Vector2 (move, 0);
			trainTwo.Position += new Vector2(move, 0);

			if (trainOne.Position.X >= trainWidth) { 
				trainOne.Position = new Vector2(trainTwo.Position.X - trainWidth, 0);
			}
			if (trainTwo.Position.X >= trainWidth) {
				trainTwo.Position = new Vector2(trainOne.Position.X - trainWidth, 0);
			}
		}
	}
	
	void OnStartPressed(){
		button.Play();
		doors.Play();

		if (state != MenuState.Moving) { return; }
		state = MenuState.Stopping;

		buttons.MouseFilter = Control.MouseFilterEnum.Ignore;

		Sprite2D leadingSprite;
		Sprite2D trailingSprite;
		if (trainOne.Position.X < trainTwo.Position.X)
		{
			leadingSprite = trainTwo;
			trailingSprite = trainOne;
		}
		else {
			leadingSprite = trainOne;
			trailingSprite = trainTwo;
		}

		float targetPos = stopX;
		if (targetPos <= leadingSprite.Position.X) {
			targetPos += trainWidth;
		}
		
		Tween tween = CreateTween();
		tween.SetParallel(true);
		tween.TweenProperty(leadingSprite, "position:x", leadingSprite.Position.X + (targetPos - leadingSprite.Position.X), stopDuration).SetEase(Tween.EaseType.Out).SetTrans(Tween.TransitionType.Cubic);
		tween.TweenProperty(trailingSprite, "position:x", trailingSprite.Position.X + (targetPos - leadingSprite.Position.X), stopDuration).SetEase(Tween.EaseType.Out).SetTrans(Tween.TransitionType.Cubic);
		tween.Chain().TweenCallback(Callable.From(OnTrainStopped));
	}

	void SetTrainSpeed(float speed) { 
		bckgdSpeed = speed;
	}
	
	void OnCreditsPressed(){
		button.Play();
		Window root = GetTree().Root;
		Node newScene = creditScene.Instantiate();

		root.AddChild(newScene);
		root.RemoveChild(currentScene);
		currentScene.QueueFree();
	}
	
	void OnQuitPressed(){
		button.Play();
		GetTree().Quit();
	}

	void OnTrainStopped()
	{
		trainOne.Visible = false;
		trainTwo.Visible = false;
		stoppedTrainScene.Visible = true;

		state = MenuState.DoorsOpening;
		OpenDoors();
	}

	void OpenDoors() {
		Vector2 leftStartingPos = leftDoor.Position;
		Vector2 rightStartingPos = rightDoor.Position;

		Tween tween = CreateTween();
		tween.SetParallel(true);
		tween.TweenProperty(leftDoor, "position", leftStartingPos + new Vector2(-doorSlidingDistance, 0), 0.6f).SetEase(Tween.EaseType.Out);
		tween.TweenProperty(rightDoor, "position", rightStartingPos + new Vector2(doorSlidingDistance, 0), 0.6f).SetEase(Tween.EaseType.Out);
		tween.Chain().TweenCallback(Callable.From(OnDoorsOpenedFinished));
	}

	void OnDoorsOpenedFinished() { 
		state = MenuState.FadingOut;

		Tween fade = CreateTween();
		fade.TweenProperty(darkness, "modulate:a", 1.0f, 0.8f);
		fade.TweenCallback(Callable.From(GoToStartScreen));
	}

	void GoToStartScreen() {
		state = MenuState.EndScene;

		Window root = GetTree().Root;
		Node newScene = startScene.Instantiate();

		root.AddChild(newScene);
		root.RemoveChild(currentScene);
		currentScene.QueueFree();
	}
}
