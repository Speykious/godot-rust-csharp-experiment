using System;
using Godot;

public class SharpWorld : Node
{
    private float timeDelayer = 0;
    private Node rustSide;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Get the HelloWorld node tat contains the Rust GDNative script
        rustSide = GetNode("HelloWorld");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        timeDelayer += delta;
        if (timeDelayer >= .5f)
        {
            // Call Rust method from C#
            rustSide.Call("print_some_counter", true);
            timeDelayer -= .5f;
        }
    }
}
