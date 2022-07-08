using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TeamIDComp))]
public class ShellExplosion : MonoBehaviour
{
    public TeamID Team;

    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
    public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
    public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
    public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
    public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
    public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

    public float m_LocateRadius = 20f;
    public float m_ShootLocateRadius = 200f;

    private Coroutine HomingCoroutine;

    [SerializeField]
    private TankShooting m_teamID;
    private Transform tankTarget = null;
    public int m_PlayerNumber;

    private TankShooting tankShooting;


    private void Update()
    {
        // Check overlap => Find target 
        Locate();
    }

    private void Start()
    {
        if (HomingCoroutine != null)
        {
            StopCoroutine(HomingCoroutine);
        }

        HomingCoroutine = StartCoroutine(Target());

        // If it isn't destroyed by then, destroy the shell after it's lifetime.
        Destroy(gameObject, m_MaxLifeTime);
    }


    private IEnumerator Target()
    {
        //yield return new WaitForSeconds(0.2f);
        Collider[] shootLocate = Physics.OverlapSphere(transform.position, m_LocateRadius, m_TankMask);
        for (int i = 0; i < shootLocate.Length; i++)
        {
            tankShooting = shootLocate[i].GetComponent<TankShooting>();
        }
        

        float time = 0;

        while (time < 1)
        {
            if ((tankTarget != null) && (tankShooting.currentShell.name == "LocateShell"))
            {
                transform.position = Vector3.Lerp(transform.position, tankTarget.position, time);
                transform.LookAt(tankTarget.position);

                time += Time.deltaTime * 0.3f;
            }
                
            yield return null;
        }
    }

    private void Locate()
    {
        Collider[] tankLocate = Physics.OverlapSphere(transform.position, m_LocateRadius, m_TankMask);

        for (int i = 0; i < tankLocate.Length; i++)
        {
            var teamID = tankLocate[i].GetComponent<TankShooting>();

            if (teamID.Team != Team)
            {
                tankTarget = teamID.transform;
            }
        }
    }

    private void ChooseShell(Transform transformActive, float time)
    {
        tankShooting.currentShell.StypeShell(transformActive, time);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        if (tankShooting.currentShell.name == "MuddyShell")
            ChooseShell(m_ExplosionParticles.gameObject.transform, m_MaxLifeTime);

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // Add an explosion force.
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            // Find the TankHealth script associated with the rigidbody.
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            // If there is no TankHealth script attached to the gameobject, go on to the next collider.
            if (!targetHealth)
                continue;

            // Calculate the amount of damage the target should take based on it's distance from the shell.
            float damage = CalculateDamage(targetRigidbody.position);

            // Deal this damage to the tank.
            targetHealth.TakeDamage(damage);
        }

        // Unparent the particles from the shell.
        m_ExplosionParticles.transform.parent = null;

        // Play the particle system.
        m_ExplosionParticles.Play();

        // Play the explosion sound effect.
        m_ExplosionAudio.Play();

        // Once the particles have finished, destroy the gameobject they are on.
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);

        // Destroy the shell.
        Destroy(gameObject);
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

    private void OnValidate()
    {
        if (!m_teamID)
            m_teamID = GetComponent<TankShooting>();
    }
}