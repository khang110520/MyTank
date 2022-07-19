using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/HealthItem")]
public class HealthItem : ItemEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        TankHealth tankHealth = target.GetComponent<TankHealth>();

        tankHealth.TakeDamage(-amount);

        if (tankHealth.m_CurrentHealth > tankHealth.m_StartingHealth)
        {
            tankHealth.m_CurrentHealth = tankHealth.m_StartingHealth;
        }
    }
}
