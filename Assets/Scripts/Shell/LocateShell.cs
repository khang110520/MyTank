using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateShell : BaseShell
{
    public override void StypeShell(Transform transform, float m_LocateRadius, LayerMask m_TankMask, TeamID Team, Transform tankTarget = null)
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
}
