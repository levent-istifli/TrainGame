using Godot;
using System;

public partial class MainMenu : Node2D
{
	[Export] public PackedScene startScene;
	[Export] public PackedScene creditScene;
	[Export] public Node currentScene;
	[Export] public Texture2D trainBackground;
	[Export] public float bckgdSpeed = 100f;

	private Sprite2D trainOne;
	private Sprite2D trainTwo;
	private float trainWidth = 1920;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
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

		AddChild(trainOne);
		AddChild(trainTwo);

    }

    private enum MenuState { Moving, Stopping, Stopped, DoorsOpening, FadingOut }
    private MenuState state = MenuState.Moving;
    
	// Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		if (state == MenuState.Stopping || state == MenuState.Moving) { 
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
		Window root = GetTree().Root;
		Node newScene = startScene.Instantiate();

		root.AddChild(newScene);
		root.RemoveChild(currentScene);
		currentScene.QueueFree();
	}
	
	void OnCreditsPressed(){
		Window root = GetTree().Root;
		Node newScene = creditScene.Instantiate();

		root.AddChild(newScene);
		root.RemoveChild(currentScene);
        currentScene.QueueFree();
    }
	
	void OnQuitPressed(){
		GetTree().Quit();
	}
}
