using Godot;
using System;

public partial class DVDBounce : Node2D
{
	[Export]
	public ColorRect BoundsRect;

	[Export]
	public Node2D Target;

	[Export]
	public ColorRect SizeRect;

	[Export]
	public Vector2 Velocity = new Vector2(100, 100);

	[Export]
	public float Speed = 100f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// No use doing this if we don't have a target set
		if (Target == null) return;
		if (BoundsRect == null) return;
		
		var pos = Target.Position;
		pos += Velocity.Normalized() * Speed * (float)delta;

		var bounds = new Rect2(
			BoundsRect.Position,
			BoundsRect.Size
		);

		var size = SizeRect.Size;

		// Bounce on X
		if (pos.X < (bounds.Position.X + (size.X / 2)) || 
			pos.X > (bounds.End.X - (size.X / 2)))
		{
			Velocity.X *= -1;
		}

		// Bounce on Y
		if (pos.Y < (bounds.Position.Y + (size.Y / 2)) || 
			pos.Y > (bounds.End.Y - (size.Y / 2)))
		{
			Velocity.Y *= -1;
		}

		Target.Position += Velocity.Normalized() * Speed * (float)delta;
	}
}
