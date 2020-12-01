using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BciMentalInput
{
    public int Neutral;
    public int Left;
    public int Right;
    public int Lift;
    public int Drop;

    // public int Push;
    // public int Pull;
    // ...

    private int limit = 20;

    public Vector2 ToDirection()
    {
        Vector2 result = Vector2.zero;
        if (Neutral > limit)
        {

        }
        if (Left > limit)
        {
            result.x = -1;
        }
        if (Right > limit)
        {
            result.x = 1;
        }
        if (Lift > limit)
        {
            result.y = 1;
        }
        if (Drop > limit)
        {
            result.y = -1;
        }

        return result;
    }

    public override string ToString()
    {
        return $"Neutral: {Neutral}, Left: {Left}, Right: {Right}, Lift: {Lift}, Drop: {Drop},";
    }
}
