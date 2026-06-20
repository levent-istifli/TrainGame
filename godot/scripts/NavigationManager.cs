using Godot;
using System;
using System.Net.Security;

public partial class NavigationManager : Node
{
	public static NavigationManager Instance { get; private set; }
	[Export] PackedScene scene_cart1;
	[Export] PackedScene scene_cart2;
	[Export] PackedScene scene_cart3;
	public string spawnDoorTag;

	//[Signal] public delegate void TriggerPlayerSpawnEventHandler(Vector2 position, string direction);

	public void goToLevel(string levelTag, string doorTag, Node2D currentLevel) {
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
			GD.Print("Scene to load isn't null");
			//Keep current scene as is and instantiate the new scene
			spawnDoorTag = doorTag;
			Node newScene = sceneToLoad.Instantiate();
			//Cast to Node2D to get properties to move the scene
			Node2D newScene2D = newScene as Node2D;
			//If done properly, move the scene 1920 to the right/left (depends on doorTag) + add to scene
			if (newScene2D != null) {
				GD.Print("Inside newScene2D check");
				if (doorTag == "L") {
					Vector2 positionChange = new Vector2(1920, 0);
					newScene2D.Position = currentLevel.Position + positionChange;
				} else if (doorTag == "R"){
					Vector2 positionChange = new Vector2(-1920, 0);
					newScene2D.Position = currentLevel.Position + positionChange;
				}

				GetTree().CurrentScene.AddChild(newScene2D);
			}

			//Window root = GetTree().Root;
			//Node current_scene = GetTree().CurrentScene;
			//root.RemoveChild(current_scene);
			//current_scene.QueueFree();
			//root.AddChild(new_scene_instance);
			//GetTree().CurrentScene = new_scene_instance;
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
