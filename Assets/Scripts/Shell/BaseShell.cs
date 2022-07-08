using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShell : ScriptableObject
{
    public abstract void StypeShell(Transform transformActive, float time);
}
