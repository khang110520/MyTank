using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/StunEffect")]
public class StunEffect : Effect
{
    public override void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
        currentEffectTime -= Time.deltaTime;

        if (targetHealth != null && currentEffectTime > 0)
        {
            Debug.Log("StopMove");
            tankMovement.StopMove();
            tankShooting.StopFire();
            //targetHealth.TakeDamage(baseDamage);
        }
        if(IsEndEffect())
        {
            tankMovement.ContinueMove();
            tankShooting.ContinueFire();
            IsStart = true;
            Debug.Log("ContinueMove");
        }
    }

    public override void StartEffect()
    {
        if (IsStart)
        {
            Debug.Log("Start");
            IsStart = false;
            currentEffectTime = effectTime;
        }
    }
}
