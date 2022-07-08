using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/MuddyShell")]
public class MuddyShell : BaseShell
{
    public GameObject mireObj;

    public override void StypeShell(Transform transformActive, float time)
    {
        GameObject shellInstance = Instantiate(mireObj, transformActive.position + new Vector3(0,0.5f,0), mireObj.transform.rotation);
        Destroy(shellInstance, time);
    }
}
