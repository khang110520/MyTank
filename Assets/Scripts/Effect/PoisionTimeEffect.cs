using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/PoisionTimeEffect")]
public class PoisionTimeEffect : Effect
{
    public float effectTime;

    private float currentEffectTime;

    public override void DoUpdate(TankHealth targetHealth)
    {
        currentEffectTime -= Time.deltaTime;

        if (targetHealth != null && currentEffectTime > 0)
        {
            targetHealth.TakeDamage(baseDamage);
        }
    }

    public override void StartEffect()
    {
        currentEffectTime = effectTime;
    }
}
