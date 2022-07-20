using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TeamIDComp))]
public class Bullet : MonoBehaviour
{
    public TeamID team;
    public BaseBullet currentBullet;
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_ExplosionAudio;
    public LayerMask m_TankMask;                       

    private void Start()
    {
        currentBullet.DoStart();
    }

    private void Update()
    {
        currentBullet.DoUpdate(transform, m_TankMask, team);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank")
        {
            other.GetComponent<TankEffect>().AddEffect(currentBullet.currentEffect);
        }

        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        m_ExplosionAudio.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);

        Destroy(gameObject);
    }
}