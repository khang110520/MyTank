using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot/Rapid")]
public class RapidShoot : BaseShoot
{
    public float timeDistance = 1f;
    public int numBulletsInTurn = 3;

    private float currentTimeDistance;
    private int currentNumBulletsInTurn;

    public override void DoUpdate(Transform firePoint, float m_CurrentLaunchForce)
    {
        currentTimeDistance -= Time.deltaTime;
        if (currentTimeDistance < 0 && currentNumBulletsInTurn > 0)
        {
            Rigidbody shellInstance =
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as Rigidbody;

            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = m_CurrentLaunchForce * firePoint.forward; ;
            currentNumBulletsInTurn--;
            currentTimeDistance = timeDistance;
        }
    }

    public override void Fire(Transform firePoint, float m_CurrentLaunchForce, float m_MinLaunchForce, float deltaTime, TeamID teamID, BaseBullet currentBullet, bool m_Fired, AudioSource m_ShootingAudio, AudioClip m_FireClip)
    {
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        Bullet shell = projectilePrefab.GetComponent<Bullet>();
        shell.team = teamID;
        shell.currentBullet = currentBullet;

        currentNumBulletsInTurn = numBulletsInTurn;

        DoUpdate(firePoint, m_CurrentLaunchForce);

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        //m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
