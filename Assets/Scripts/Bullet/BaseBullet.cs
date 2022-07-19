using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : ScriptableObject
{
    public Effect currentEffect;

    public virtual void DoStart(GameObject gameObject)
    {
    }

    public virtual void DoUpdate(Transform transform, LayerMask m_TankMask, TeamID team)
    {
    }
}
