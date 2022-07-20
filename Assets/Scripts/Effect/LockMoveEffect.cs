using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/LockMoveEffect")]
public class LockMoveEffect : Effect
{
    public override void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
        currentEffectTime -= Time.deltaTime;

        if (currentEffectTime > 0)
        {
            Debug.Log("StopMove");
            tankMovement.StopMove();
        }
        if (IsEndEffect())
        {
            tankMovement.ContinueMove();
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
