using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShell : ScriptableObject
{
    // Chuyen thanh MOno

    public virtual void DoStart()
    {
    }

    public virtual void DoUpdate(Transform transform, LayerMask m_TankMask, TeamID team)
    {
    }
    
    public virtual void DoOnTriggerEnter(Transform transformExplosion, string other, GameObject gameObject)
    {
    }

    public abstract float CalculateDamage(Vector3 targetRigidbody);
}
