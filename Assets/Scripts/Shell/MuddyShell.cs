using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/MuddyShell")]
public class MuddyShell : BaseShell
{
    public GameObject poisonZone;

    public override void DoUpdate(Transform transform)
    {
        base.DoUpdate(transform);
    }

    public override void DoOnTrigger(Transform transform, float m_ExplosionRadius, LayerMask m_TankMask, TeamID team, float m_ExplosionForce, ParticleSystem m_ExplosionParticles, AudioSource m_ExplosionAudio)
    {
        base.DoOnTrigger(transform, m_ExplosionRadius, m_TankMask, team, m_ExplosionForce, m_ExplosionParticles, m_ExplosionAudio);
        GameObject shellInstance = Instantiate(poisonZone, m_ExplosionParticles.transform.position + new Vector3(0, 0.5f, 0), poisonZone.transform.rotation);
        //Destroy(shellInstance, time);
    }

    public override float CalculateDamage(Vector3 targetRigidbody)
    {
        throw new System.NotImplementedException();
    }
}
