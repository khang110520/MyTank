using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Effect : ScriptableObject
{
    public float baseDamage;

    public abstract void StartEffect();

    public virtual void DoUpdate(TankHealth targetHealth)
    {
    }
}
