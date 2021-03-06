using UnityEngine;

public abstract class BaseShoot : ScriptableObject
{
    public Rigidbody projectilePrefab;
    public float interval;
    //m_MinLaunchForce
    //m_MaxLaunchForce

    public virtual void DoUpdate(Transform firePoint, float m_CurrentLaunchForce)
    {
        
    }
    public abstract void Fire(Transform firePoint, float m_CurrentLaunchForce, float m_MinLaunchForce, float deltaTime, TeamID teamID, BaseBullet currentBullet, bool m_Fired, AudioSource m_ShootingAudio, AudioClip m_FireClip);

}
