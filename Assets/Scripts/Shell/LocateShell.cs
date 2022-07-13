using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/LocateShell")]
public class LocateShell : BaseShell
{
    public float m_LocateRadius;
    public float m_ShellSpeed;

    private Transform tankTarget = null;

    public override void DoUpdate(Transform transform)
    {
        Debug.Log(tankTarget);
        Target(transform);
    }

    public override void DoOnTrigger(Transform transform, float m_ExplosionRadius, LayerMask m_TankMask, TeamID team, float m_ExplosionForce, ParticleSystem m_ExplosionParticles, AudioSource m_ExplosionAudio)
    {
        Locate(transform, m_TankMask, team);

        base.DoOnTrigger(transform, m_ExplosionRadius, m_TankMask, team, m_ExplosionForce, m_ExplosionParticles, m_ExplosionAudio);
        tankTarget = null;
    }

    private void Locate(Transform transform, LayerMask m_TankMask, TeamID team)
    {
        Collider[] tankLocate = Physics.OverlapSphere(transform.position, m_LocateRadius, m_TankMask);

        Debug.Log(tankLocate);

        for (int i = 0; i < tankLocate.Length; i++)
        {
            var teamID = tankLocate[i].GetComponent<TankShooting>();

            if (teamID.Team != team)
            {
                tankTarget = teamID.transform;
            }
        }

    }

    private void Target(Transform transform)
    {
        if ((tankTarget != null))
        {
            transform.position = Vector3.Lerp(transform.position, tankTarget.position, m_ShellSpeed * Time.deltaTime);
            transform.LookAt(tankTarget.position);
        }
    }

    public override float CalculateDamage(Vector3 targetRigidbody)
    {
        throw new System.NotImplementedException();
    }
}
