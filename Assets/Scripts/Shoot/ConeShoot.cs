using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot/Cone")]
public class ConeShoot : BaseShoot
{
    public override void Fire(Transform firePoint, float Force, TeamID teamID)
    {
        for (int i = -2; i <= 2; i++)
        {
            Vector3 bulletPosition = firePoint.position;
            Vector3 bulletRotation = firePoint.rotation.eulerAngles;
            bulletRotation.y += 15f * i;

            shell.GetComponent<ShellExplosion>().Team = teamID;

            Rigidbody shellInstance =
            Instantiate(shell, bulletPosition, Quaternion.Euler(bulletRotation)) as Rigidbody;

            shellInstance.velocity = Force * shellInstance.transform.forward; ;
        }
    }
}
