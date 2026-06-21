using Godot;
using System;
using System.Net.Security;

public partial class NavigationManager : Node
{
	public static NavigationManager Instance { get; private set; }
	private readonly PackedScene scene_cart1 = GD.Load<PackedScene>("res://scenes/TestScene.tscn");
	private readonly PackedScene scene_cart2 = GD.Load<PackedScene>("res://scenes/TestScene2.tscn");
	private readonly PackedScene scene_cart3 = GD.Load<PackedScene>("res://scenes/TestScene3.tscn");
	public string spawnDoorTag;

	//[Signal] public delegate void TriggerPlayerSpawnEventHandler(Vector2 position, string direction);

	public void goToLevel(string levelTag, string doorTag, Node2D currentLevel, CharacterBody2D player) {
		//GD.Print("In gotolevel");
		PackedScene sceneToLoad;

		//Match the level tag/name with the corresponding scenes, save it in sceneToLoad
		sceneToLoad = levelTag switch {
			"TestScene" => scene_cart1,
			"TestScene2" => scene_cart2,
			"TestScene3" => scene_cart3,
			_ => null
		};

		if (sceneToLoad != null) {
			//GD.Print("Scene to load isn't null");
			//Keep current scene as is and instantiate the new scene
			spawnDoorTag = doorTag;
			Node newScene = sceneToLoad.Instantiate();
			//Cast to Node2D to get properties to move the scene
			Node2D newScene2D = newScene as Node2D;
			//If done properly, move the scene 1920 to the right/left (depends on doorTag) + add to scene
			float finalCamPos = 0;
			GD.Print("Camera Pos Before Move: ", Camera2d.Instance.Position);
			if (newScene2D != null) {
				//GD.Print("Inside newScene2D check");
				//Check if left or right door to spawn room in correct position + adjust camera correctly
				if (doorTag == "L") {
					Vector2 positionChange = new Vector2(1920, 0);
					newScene2D.Position = currentLevel.Position + positionChange;
					finalCamPos = (Camera2d.Instance.Position + positionChange).X;
				} else if (doorTag == "R"){
					Vector2 positionChange = new Vector2(-1920, 0);
					newScene2D.Position = currentLevel.Position + positionChange;
					finalCamPos = (Camera2d.Instance.Position + positionChange).X;
				}

				//Add new scene, hide player, tween camera, move player in new position next to door and unhide
				Callable.From(() => GetTree().Root.GetNode("MainTestScene").AddChild(newScene2D)).CallDeferred();
				player.Hide();
				Callable.From(() => Camera2d.Instance.MoveCamera(finalCamPos)).CallDeferred();
				//GD.Print("Final Cam Pos: ", finalCamPos);
				//Callable.From(() => GetTree().Root.GetNode("MainTestScene").RemoveChild(currentLevel)).CallDeferred();
				//currentLevel.QueueFree();
			}
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
