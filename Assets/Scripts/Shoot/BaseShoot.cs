using UnityEngine;

public abstract class BaseShoot : ScriptableObject
{
    public Rigidbody projectilePrefab;
    public float interval;
    //m_MinLaunchForce
    //m_MaxLaunchForce

    public virtual void DoUpdate(float deltaTime)
    {
        
    }
    public abstract void Fire(Transform firePoint, float m_CurrentLaunchForce, float m_MinLaunchForce, float deltaTime, TeamID teamID, BaseShell currentShell, bool m_Fired, AudioSource m_ShootingAudio, AudioClip m_FireClip);

}
