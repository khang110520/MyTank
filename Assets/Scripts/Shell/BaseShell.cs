using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShell : ScriptableObject
{
    public GameObject shell;
    public GameObject mireObj;

    public abstract void StypeShell(Transform transform, float m_LocateRadius, LayerMask m_TankMask, TeamID Team, Transform tankTarget = null);
}
