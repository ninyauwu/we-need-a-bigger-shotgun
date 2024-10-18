using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : ScriptableObject
{
    public float Health;
    public float Attack;
    public float Speed;

    public Stats Clone()
    {
        Stats clone = Instantiate(this);
        return clone;
    }
}
