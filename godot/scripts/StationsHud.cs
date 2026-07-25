using Godot;
using System;
using System.Reflection.Metadata;

public partial class StationsHud : Control
{
	public const double circleSpacing = 100.0;
	[Export] public Texture2D whiteSquareTexture;
	[Export] public TextureRect currentPositionMarker;
	[Export] public Line2D line;
	[Export] public Label label;
	public static StationsHud Instance { get; private set; }
	public override void _Ready()
	{
		Instance = this;
		var numStations = NavigationManager.stationNames.Length;
		line.AddPoint(new Vector2((numStations - 0.5f) * (float)circleSpacing, 32));
		for(int i = 0; i < NavigationManager.stationNames.Length; i++)
		{
            var newTextureRect = new TextureRect
            {
                Texture = whiteSquareTexture,
                Position = new Vector2((float)(i * circleSpacing), 0)
            };
            AddChild(newTextureRect);
		}

	}
}
