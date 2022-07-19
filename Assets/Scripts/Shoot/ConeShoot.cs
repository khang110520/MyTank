using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot/Cone")]
public class ConeShoot : BaseShoot
{
    public float shotAngle = 15f;

    public override void Fire(Transform firePoint, float m_CurrentLaunchForce, float m_MinLaunchForce, float deltaTime, TeamID teamID, BaseBullet currentBullet, bool m_Fired, AudioSource m_ShootingAudio, AudioClip m_FireClip)
    {
        m_Fired = true;

        for (int i = -2; i <= 2; i++)
        {
            Vector3 bulletRotation = firePoint.rotation.eulerAngles;
            bulletRotation.y += shotAngle * i;

            Bullet shell = projectilePrefab.GetComponent<Bullet>();
            shell.team = teamID;
            shell.currentBullet = currentBullet;

            Rigidbody shellInstance =
                Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(bulletRotation)) as Rigidbody;

            shellInstance.velocity = m_CurrentLaunchForce * shellInstance.transform.forward;
        }

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        //m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
