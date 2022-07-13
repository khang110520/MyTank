using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TeamIDComp))]
public class Shell : MonoBehaviour
{
    public TeamID team;
    public BaseShell currentShell;

    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
    public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
    public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
    public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
    public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
    public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void Update()
    {
        currentShell.DoUpdate(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentShell.DoOnTrigger(transform, m_ExplosionRadius, m_TankMask, team, m_ExplosionForce, m_ExplosionParticles, m_ExplosionAudio);
        
        // Destroy the shell.
    }



    private float CalculateDamage(Vector3 targetPosition)
    {
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        // Calculate damage as this proportion of the maximum possible damage.
        float damage = relativeDistance * m_MaxDamage;

        // Make sure that the minimum damage is always 0.
        damage = Mathf.Max(0f, damage);

        return damage;
    }
}