using Godot;
using System;
using System.Net.Security;
using System.Threading.Tasks;
using GodotStringIntercept;

public partial class NavigationManager : Node
{
	// singleton pattern - single instance of class that can be used in each of scenes to prevent restarting of items or counters
	public static NavigationManager Instance { get; private set; }

	// preload scenes
	private readonly PackedScene scene_cart1 = GD.Load<PackedScene>("res://scenes/TestScene.tscn");

	private readonly PackedScene scene_cart2 = GD.Load<PackedScene>("res://scenes/TestScene2.tscn");
	private readonly PackedScene scene_cart3 = GD.Load<PackedScene>("res://scenes/TestScene3.tscn");
	public string spawnDoorTag;


	private readonly PackedScene scene_dialogue_collectables = GD.Load<PackedScene>("res://scenes/MCDialogue.tscn");
	private readonly PackedScene back_button = GD.Load<PackedScene>("res://scenes/MCDialogue.tscn");
	private Node currentDialogueScene;

	public int currentStation = 0;
	public enum TrainState {
		STOPPED,
		RUNNING,
		SLOWING
	}

	public TrainState currentTrainState = TrainState.SLOWING;

	public Timer trainTimer;

	public Godot.Collections.Array<Node> NPCSpawners;

	public bool IsDialogueSceneOpen()
	{
		return currentDialogueScene != null && GodotObject.IsInstanceValid(currentDialogueScene);
	}

	public void removeDialogueScene()
	{
		// remove current scene (aka dialogue - character interaction scene)
		var nodesToPause = GetTree().GetNodesInGroup("Pause".AsStringName());
		for (int i = 0; i < nodesToPause.Count; i++)
		{
			nodesToPause[i].ProcessMode = ProcessModeEnum.Inherit;
			nodesToPause[i].Set("visible".AsStringName(), true);
		}
		Window root = GetTree().Root;
		Node currentScene = IsDialogueSceneOpen() ? currentDialogueScene : null;

		if (currentScene == null)
		{
			currentDialogueScene = null;
			return;
		}

		root.RemoveChild(currentScene); 
		currentScene.QueueFree();
		currentDialogueScene = null;
	}

	public void loadDialogueScene(string sceneTag, string doorTag, string dialogueEventId = "")
	{
		if (sceneTag == "MCDialogue" && IsDialogueSceneOpen())
		{
			return;
		}

		Window root = GetTree().Root;


		PackedScene sceneToLoad;
		sceneToLoad = sceneTag switch {
			"TestScene" => scene_cart1,
			"TestScene2" => scene_cart2,
			"TestScene3" => scene_cart3,
			"MCDialogue" => scene_dialogue_collectables,
			_ => null
		};

		if (sceneToLoad != null) {
			spawnDoorTag = sceneTag;
			Node newScene = sceneToLoad.Instantiate();

			if (!string.IsNullOrEmpty(dialogueEventId) && newScene is DialogueTestUser dialogueScene)
			{
				dialogueScene.dialogueEventId = dialogueEventId;
			}

			// add new scene (aka. dialogue/character interaction scene)
			if (sceneTag == "MCDialogue")
			{
				currentDialogueScene = newScene;
			}

			root.AddChild(newScene);
			GetTree().CurrentScene = newScene;

			var nodesToPause = GetTree().GetNodesInGroup("Pause".AsStringName());
			for (int i = 0; i < nodesToPause.Count; i++)
			{
				nodesToPause[i].ProcessMode = ProcessModeEnum.Disabled;
				nodesToPause[i].Set("visible".AsStringName(), false);
			}
		}

	}

	public async Task goToLevel(string levelTag, string doorTag, Node2D nextLevel, CharacterBody2D player) {
		spawnDoorTag = doorTag;
		float finalCamPos = 0;

		if (doorTag == "L")
		{
			Vector2 positionChange = new Vector2(1920, 0);
			finalCamPos = (Camera2d.Instance.Position + positionChange).X;
		}
		else if (doorTag == "R")
		{
			Vector2 positionChange = new Vector2(-1920, 0);
			finalCamPos = (Camera2d.Instance.Position + positionChange).X;
		}

		player.Hide();
		Tween tween = Camera2d.Instance.MoveCamera(finalCamPos);
		await ToSignal(tween, Tween.SignalName.Finished);

		Node2D nextLevel2D = nextLevel as Node2D;

		Marker2D newSpawn = FindSpawner(nextLevel, doorTag);
		if (newSpawn != null)
		{
			player.GlobalPosition = newSpawn.GlobalPosition;

			player.Show();
		}
	}



	public Marker2D FindSpawner(Node2D sceneWithDoor, string destDoorTag) {
		//Goes through the nodes in the spawn points group and picks the correct spawn point for the current scene
		var spawns = GetTree().GetNodesInGroup("Spawn Points".AsStringName());
		for (int i = 0; i < spawns.Count; i++) {
			Node2D current = spawns[i] as Node2D;

			if (current != null && sceneWithDoor.IsAncestorOf(current)) {
				Spawn spawnPoint = spawns[i] as Spawn;
				if (spawnPoint != null && spawnPoint.GetDoorTag() == destDoorTag) {
					return spawnPoint;
				}
			}
		}
		return null;
	}

	public void onTrainTimerTimeout()
	{
		switch(currentTrainState) 
		{
			case TrainState.STOPPED:
				currentTrainState = TrainState.RUNNING;
				foreach(Node spawner in NPCSpawners)
				{
					spawner.Call("stop_boarding".AsStringName());
				}
				{
				Tween cameraShakeTween = CreateTween();
				cameraShakeTween.SetProcessMode(Tween.TweenProcessMode.Physics);
				cameraShakeTween.TweenProperty(Camera2d.Instance, "shakeIntensity".AsNodePath(), 2.0, 2.0);
				}
				trainTimer.WaitTime = 10.0;
				trainTimer.Start();
				break;
			case TrainState.RUNNING:
				currentTrainState = TrainState.SLOWING;
				{
				Tween cameraShakeTween = CreateTween();
				cameraShakeTween.SetProcessMode(Tween.TweenProcessMode.Physics);
				cameraShakeTween.TweenProperty(Camera2d.Instance, "shakeIntensity".AsNodePath(), 0.0, 2.0);
				cameraShakeTween.TweenCallback(Callable.From(onTrainTimerTimeout));
				}
				break;
			case TrainState.SLOWING:
				currentTrainState = TrainState.STOPPED;
				foreach(Node spawner in NPCSpawners)
				{
					spawner.Call("start_boarding".AsStringName());
					spawner.Call("start_exiting".AsStringName());
				}
				trainTimer.WaitTime = 10.0;
				trainTimer.Start();
				break;
		}
	}

	private void getNPCSpawners()
	{
		NPCSpawners = GetTree().GetNodesInGroup("NPC Spawner".AsStringName());
		onTrainTimerTimeout();
	}
	
	// Called when the node enters the scene tree for the first time.
	// To check if instance has been intitiated, if so return it
	public override void _Ready()
	{
		AddToGroup("Pause".AsStringName());
		Instance = this;
		trainTimer = new Timer
		{
			ProcessCallback = Timer.TimerProcessCallback.Physics,
			OneShot = true
		};
		trainTimer.Timeout += onTrainTimerTimeout;
		AddChild(trainTimer);
		Callable.From(getNPCSpawners).CallDeferred();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
