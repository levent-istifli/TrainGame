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
	// private readonly PackedScene scene_cart2 = GD.Load<PackedScene>("res://scenes/NpcInteraction.tscn");

	private readonly PackedScene scene_cart2 = GD.Load<PackedScene>("res://scenes/TestScene2.tscn");
	private readonly PackedScene scene_cart3 = GD.Load<PackedScene>("res://scenes/TestScene3.tscn");
	public string spawnDoorTag;


	private readonly PackedScene scene_dialogue_collectables = GD.Load<PackedScene>("res://scenes/MCDialogue.tscn");
	private readonly PackedScene back_button = GD.Load<PackedScene>("res://scenes/MCDialogue.tscn");
	private Node currentDialogueScene;


	private readonly HashSet<string> storyFlags = new();
	public void SetStoryFlag(string flag) => storyFlags.Add(flag);
	public bool HasStoryFlag(string flag) => storyFlags.Contains(flag);

	
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
		// Node currentScene = GetTree().CurrentScene;


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
			
			// root.RemoveChild(currentScene);
			// currentScene.QueueFree();

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

		//          if (sceneToLoad != null) {
		//	//GD.Print("Scene to load isn't null");
		//	//Keep current scene as is and instantiate the new scene
		//	spawnDoorTag = doorTag;
		//	//Node newScene = sceneToLoad.Instantiate();
		//	//Cast to Node2D to get properties to move the scene
		//	//Node2D newScene2D = newScene as Node2D;
		//	//If done properly, move the scene 1920 to the right/left (depends on doorTag) + add to scene
		//	float finalCamPos = 0;
		//	//GD.Print("Camera Pos Before Move: ", Camera2d.Instance.Position);
		//	if (newScene2D != null) {
		//		//GD.Print("Inside newScene2D check");

		//		//Check if left or right door to spawn room in correct position + adjust camera correctly
		//		if (doorTag == "L") {
		//			Vector2 positionChange = new Vector2(1920, 0);
		//			//newScene2D.Position = currentLevel.Position + positionChange;
		//			finalCamPos = (Camera2d.Instance.Position + positionChange).X;
		//		} else if (doorTag == "R"){
		//			Vector2 positionChange = new Vector2(-1920, 0);
		//			newScene2D.Position = currentLevel.Position + positionChange;
		//			finalCamPos = (Camera2d.Instance.Position + positionChange).X;
		//		}

		//		//Add new scene, hide player, tween camera, move player in new position next to door and unhide
		//		//Callable.From(() => GetTree().Root.GetNode("MainScene".AsNodePath()).AddChild(newScene2D)).CallDeferred();
		//		//await ToSignal(GetTree(), "process_frame".AsStringName());
		//		player.Hide();
		//		Tween tween = Camera2d.Instance.MoveCamera(finalCamPos);
		//		await ToSignal(tween, Tween.SignalName.Finished);
		//		//Callable.From(() => currentLevel.QueueFree()).CallDeferred();  //compleltley deletes from memory, so you lose saved state
		//		//GD.Print("Group size: ", GetTree().GetNodesInGroup("Spawn Points".AsStringName()).Count);
		//		Marker2D newSpawn = FindSpawner(newScene2D, doorTag);
		//		if (newSpawn != null) {
		//			//GD.Print("New spawn isn't null");
		//			//GD.Print("New Spawn position: " + newSpawn.GlobalPosition);
		//			//GD.Print("Current Player position" + player.GlobalPosition);
		//			player.GlobalPosition = newSpawn.GlobalPosition;

		//			player.Show();
		//		}

		//		//GD.Print("Final Cam Pos: ", finalCamPos);
		//	}
		//}
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
	
	// Called when the node enters the scene tree for the first time.
	// To check if instance has been intitiated, if so return it
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
