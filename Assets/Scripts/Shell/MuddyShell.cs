using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/MuddyShell")]
public class MuddyShell : BaseShell
{
    public GameObject poisonZone;

    public override void DoOnTriggerEnter(Transform transformExplosion, string other, GameObject gameObject)
    {
        GameObject shellInstance = Instantiate(poisonZone, transformExplosion.position + poisonZone.transform.position, poisonZone.transform.rotation);
    }

    public override float CalculateDamage(Vector3 targetRigidbody)
    {
        throw new System.NotImplementedException();
    }
}
