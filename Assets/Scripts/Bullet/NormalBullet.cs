using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet/NormalBullet")]
public class NormalBullet : BaseBullet
{
    public LayerMask m_TankMask;
    public float m_ExplosionForce = 50f;
    public float m_ExplosionRadius = 5f;

    private Rigidbody targetRigidbody;

    public override void DoStart(GameObject gameObject)
    {
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, m_ExplosionRadius, m_TankMask);

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            TankEffect tankEffect = colliders[i].GetComponent<TankEffect>();

            // If they don't have a rigidbody, go on to the next collider.
            if (!tankEffect)
                continue;

            currentEffect.baseDamage *= CalculateDistance(gameObject);

            tankEffect.AddEffect(currentEffect);

            // Add an explosion force.
            targetRigidbody.AddExplosionForce(m_ExplosionForce, gameObject.transform.position, m_ExplosionRadius);

        }
        // Destroy the shell.
        Destroy(gameObject);
    }

    public float CalculateDistance(GameObject gameObject)
    {
        Vector3 targetPosition = targetRigidbody.position;
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - gameObject.transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        return relativeDistance;
    }

}
