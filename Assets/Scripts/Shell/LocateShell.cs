using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shell/LocateShell")]
public class LocateShell : BaseShell
{
    public GameObject Shell;

    public override void StypeShell(Transform transformActive, float time)
    {
        Shell.transform.position = Vector3.Lerp(Shell.transform.position, transformActive.position, time);
        Shell.transform.LookAt(transformActive.position);

        time += Time.deltaTime * 0.3f;
    }

}
