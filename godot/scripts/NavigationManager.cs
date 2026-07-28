using Godot;
using System;
using System.Net.Security;
using System.Threading.Tasks;
using GodotStringIntercept;
using System.Collections.Generic;

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


	private readonly HashSet<string> storyFlags = new();
	public void SetStoryFlag(string flag) => storyFlags.Add(flag);
	public bool HasStoryFlag(string flag) => storyFlags.Contains(flag);

	
	public List<string> boardQueue = new List<string>();
	public List<string> exitQueue = new List<string>();

	public int currentStation = 0;
	public static readonly string[] stationNames = {"Ichi", "Ni", "San", "Shi", "Go", "Roku", "Shichi", "Hachi", "Kyuu", "Juu", "Juuichi", "Juuni"};
	public enum TrainState {
		STOPPED,
		RUNNING,
		SLOWING
	}

	public TrainState currentTrainState = TrainState.SLOWING;

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

	public void startTrain()
	{
		currentTrainState = TrainState.RUNNING;
		StationsHud.Instance.label.Text = "Heading to " + stationNames[currentStation + 1] + " Station";
		{
		var tween = CreateTween();
		tween.SetProcessMode(Tween.TweenProcessMode.Physics);
		tween.TweenProperty(StationsHud.Instance.currentPositionMarker, "position:x".AsNodePath(), (currentStation + 0.5) * StationsHud.circleSpacing , 3.0);
		}
		foreach(Node spawner in NPCSpawners)
		{
			spawner.Call("stop_boarding".AsStringName());
		}
		{
		Tween cameraShakeTween = CreateTween();
		cameraShakeTween.SetProcessMode(Tween.TweenProcessMode.Physics);
		cameraShakeTween.TweenProperty(Camera2d.Instance, "shakeIntensity".AsNodePath(), 2.0, 2.0);
		}
	}

	public void stopTrain()
	{
		currentTrainState = TrainState.SLOWING;
		StationsHud.Instance.label.Text = "Arriving at " + stationNames[currentStation + 1] + " Station";
		var tween = CreateTween();
		tween.SetProcessMode(Tween.TweenProcessMode.Physics);
		tween.TweenProperty(StationsHud.Instance.currentPositionMarker, "position:x".AsNodePath(), (currentStation + 1) * StationsHud.circleSpacing, 3.0);
		Tween cameraShakeTween = CreateTween();
		cameraShakeTween.SetProcessMode(Tween.TweenProcessMode.Physics);
		cameraShakeTween.TweenProperty(Camera2d.Instance, "shakeIntensity".AsNodePath(), 0.0, 3.0);
		cameraShakeTween.TweenCallback(Callable.From(finishStopTrain));
	}

	public void finishStopTrain()
	{
		currentTrainState = TrainState.STOPPED;
		foreach(Node spawner in NPCSpawners)
		{
			spawner.Call("start_boarding".AsStringName());
			spawner.Call("start_exiting".AsStringName());
		}
		foreach(string name in boardQueue)
		{
			var npc = (NpcPlayerMover)GetTree().GetNodesInGroup(new StringName(name))[0];
			npc.BoardTrain();
		}
		foreach(string name in exitQueue)
		{
			var npc = (NpcPlayerMover)GetTree().GetNodesInGroup(new StringName(name))[0];
			npc.ExitTrain();
		}
		boardQueue.Clear();
		currentStation += 1;
		StationsHud.Instance.label.Text = "Arrived at " + stationNames[currentStation] + " Station";
	}

	public void getNPCSpawners()
	{
		NPCSpawners = GetTree().GetNodesInGroup("NPC Spawner".AsStringName());
	}
	
	// Called when the node enters the scene tree for the first time.
	// To check if instance has been intitiated, if so return it
	public override void _Ready()
	{
		AddToGroup("Pause".AsStringName());
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
