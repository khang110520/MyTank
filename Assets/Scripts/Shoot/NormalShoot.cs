using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot/Normal")]
public class NormalShoot : BaseShoot
{
    public override void Fire(Transform firePoint, float m_CurrentLaunchForce, float m_MinLaunchForce, float deltaTime, TeamID teamID, BaseShell currentShell, bool m_Fired, AudioSource m_ShootingAudio, AudioClip m_FireClip)
    {
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        Shell shell = projectilePrefab.GetComponent<Shell>();
        shell.team = teamID;
        shell.currentShell = currentShell;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * firePoint.forward; ;

        

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
