using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : Effect
{
    public LayerMask m_TankMask;
    public float m_ExplosionForce = 50f;
    public float m_ExplosionRadius = 5f;
    public float relativeDistance;

    public override void DoUpdate(TankHealth targetHealth)
    {
        targetHealth.TakeDamage(baseDamage);
    }

    public override void StartEffect()
    {
    }

    public float CalculateDamage(GameObject target, GameObject gameObject)
    {
        Vector3 targetPosition = target.transform.position;
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - gameObject.transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        //float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        // Calculate damage as this proportion of the maximum possible damage.
        float damage = relativeDistance * baseDamage;

        // Make sure that the minimum damage is always 0.
        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
