using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/PoisionTimeEffect")]
public class PoisionTimeEffect : Effect
{
    public float baseDamage;

    public override void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
        currentEffectTime -= Time.deltaTime;

        if (currentEffectTime > 0)
        {
            targetHealth.TakeDamage(baseDamage);
        }

        if (IsEndEffect())
        {
            IsStart = true;
        }
    }

    public override void StartEffect()
    {
        if (IsStart)
        {
            Debug.Log("Start");
            IsStart = false;
            currentEffectTime = effectTime;
        }
    }
}
