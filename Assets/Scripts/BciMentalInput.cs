using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BciMentalInput
{
    public int Threshold = 20;

    public int Neutral;
    public int Left;
    public int Right;
    //public int Lift;
    //public int Drop;
    // public int Push;
    // public int Pull;
    // ...

    public bool IsNeutral => true;//(Neutral >= Threshold);
    public bool IsLeft => (Left >= Threshold);
    public bool IsRight => (Right >= Threshold);
    //public bool IsLift => (Left >= Threshold);
    //public bool IsDrop => (Left >= Threshold);


    public Vector2 ToDirection()
    {
        Vector2 result = Vector2.zero;
        if (IsNeutral)
        {
        }
        if (IsLeft)
        {
            result.x = -1;
        }
        if (IsRight)
        {
            result.x = 1;
        }
        /*
        if (IsLift)
        {
            result.y = 1;
        }
        if (IsDrop)
        {
            result.y = -1;
        }
        */

        return result;
    }

    public override string ToString()
    {
        return $"Neutral: {Neutral}, Left: {Left}, Right: {Right}";
    }
}
