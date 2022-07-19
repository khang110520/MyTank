using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/PoisonPercentEffect")]
public class PoisonPercentEffect : Effect
{
    public float damagePercent;

    public override void DoUpdate(TankHealth targetHealth)
    {
        
        targetHealth.TakeDamage(targetHealth.m_StartingHealth * damagePercent / 100);
    }

    public override void StartEffect()
    {
    }

}
