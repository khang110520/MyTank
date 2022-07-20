using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/PoisonPercentEffect")]
public class PoisonPercentEffect : Effect
{
    public float baseDamage;
    public float damagePercent;

    public override void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
        currentEffectTime -= Time.deltaTime;
        if (IsEndEffect())
        {
            targetHealth.TakeDamage(targetHealth.m_StartingHealth * damagePercent / 100);
            IsStart = true;
            Debug.Log("End");
        }
    }

    public override void StartEffect()
    {
        if (IsStart)
        {
            Debug.Log("Start");
            IsStart = false;
        }
    }

}
