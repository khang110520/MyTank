using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/MuddyShell")]
public class MuddyShell : BaseShell
{
    public GameObject mireObj;

    public override void StypeShell(Transform transformActive, float time)
    {
        GameObject shellInstance = Instantiate(mireObj, transformActive.position, transformActive.rotation);
        Destroy(shellInstance, time);
    }
}
