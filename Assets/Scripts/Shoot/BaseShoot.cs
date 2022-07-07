using UnityEngine;

public abstract class BaseShoot : ScriptableObject
{
    public Rigidbody shell;
    public abstract void Fire(Transform firePoint, float Force, TeamID teamID);
}
