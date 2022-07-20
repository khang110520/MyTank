using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Effect : ScriptableObject
{
    public float baseDamage;
    public float effectTime;
    public float currentEffectTime;
    public bool IsStart = true;

    public abstract void StartEffect();

    public virtual void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
    }

    public virtual bool IsEndEffect()
    {

        return currentEffectTime < 0;
    }

    
}
