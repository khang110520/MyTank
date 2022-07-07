using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot/Normal")]
public class NormalShooot : BaseShoot
{
    public override void Fire(Transform firePoint, float force, TeamID teamID)
    {
        Vector3 bulletPosition = firePoint.position;
        Vector3 bulletRotation = firePoint.rotation.eulerAngles;

        shell.GetComponent<ShellExplosion>().Team = teamID;

        Rigidbody shellInstance = Instantiate(shell, bulletPosition, Quaternion.Euler(bulletRotation));
        shellInstance.velocity = force * firePoint.forward;
    }
}
