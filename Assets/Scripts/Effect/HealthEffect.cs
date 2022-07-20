using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/HealthEffect")]
public class HealthEffect : Effect
{
    public float healthUp;
    private float maxHealth = 100f;

    public override void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
        currentEffectTime -= Time.deltaTime;

        if (currentEffectTime > 0)
        {
            targetHealth.TakeDamage(-healthUp);

            if (targetHealth.m_CurrentHealth > maxHealth)
            {
                targetHealth.m_CurrentHealth = maxHealth;
            }
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
