using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/LocateShell")]
public class LocateShell : BaseShell
{
    public float m_LocateRadius;
    public float m_ShellSpeed;
    private Transform tankTarget;

    public override void DoStart()
    {
        if(tankTarget != null)
        {
            tankTarget = null;
        }
    }

    public override void DoUpdate(Transform transform, LayerMask m_TankMask, TeamID team)
    {
        FindTarget(transform, m_TankMask, team);
    }

    public void FindTarget(Transform transform, LayerMask m_TankMask, TeamID team)
    {
        //Locate
        Collider[] tankLocate = Physics.OverlapSphere(transform.position, m_LocateRadius, m_TankMask);

        for (int i = 0; i < tankLocate.Length; i++)
        {
            var teamID = tankLocate[i].GetComponent<TankShooting>();

            if (teamID.Team != team)
            {
                tankTarget = teamID.transform;
            }
        }

        //Target
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
