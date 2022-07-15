using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/SpreadShell")]
public class SpreadShell : BaseShell
{
    public float m_LocateRadius;
    public float m_ShellSpeed;
    public int numTarget = 2;

    private Transform tankTarget;
    private Transform nextTarget;
    private bool isRealy;
    private int numTargeted;

    public override void DoStart()
    {
        isRealy = false;
        numTargeted = numTarget;


    }

    public override void DoOnTriggerEnter(Transform transformExplosion, string other, GameObject gameObject)
    {
        Debug.Log(numTargeted);
        Debug.Log(other);


        if (other == "Tank" && numTargeted > 0)
        {
            Debug.Log(1111);
            isRealy = true;
            numTargeted--;
        }
        else
        {
            numTargeted = numTarget;
            if (nextTarget != null && nextTarget != null)
            {
                tankTarget = null;
                nextTarget = null;
            }
            Destroy(gameObject);
        }
    }

    public override void DoUpdate(Transform transform, LayerMask m_TankMask, TeamID team)
    {
        if (isRealy)
        {
            Debug.Log("Find");
            FindTarget(transform, m_TankMask, team);
        }
        
    }

    public void FindTarget(Transform transform, LayerMask m_TankMask, TeamID team)
    {
        
        //Locate
        Collider[] tankLocate = Physics.OverlapSphere(transform.position, m_LocateRadius, m_TankMask);

        for (int i = 0; i < tankLocate.Length - 1; i++)
        {
            var teamID = tankLocate[i].GetComponent<TankShooting>();


            if (teamID.Team != team)
            {
                Debug.Log(teamID.transform);

                if (nextTarget == null)
                {
                    nextTarget = teamID.transform;
                }
            }
        }



        //Target
        if ((nextTarget != null))
        {
            Debug.Log("target");
            transform.position = Vector3.Lerp(transform.position, nextTarget.position, m_ShellSpeed * Time.deltaTime);
            transform.LookAt(nextTarget.position);
            tankTarget = nextTarget;
            isRealy = false;
        }
    }

    public override float CalculateDamage(Vector3 targetRigidbody)
    {
        throw new System.NotImplementedException();
    }
}