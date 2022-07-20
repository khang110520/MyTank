using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/SpeedUpEffeect")]
public class SpeedUpEffeect : Effect
{
    public float SpeedUp;
    private float currentSpeedUp;

    public override void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
        currentEffectTime -= Time.deltaTime;
        Debug.Log(tankMovement.m_Speed);
        if (!IsEndEffect())
        {
            Debug.Log("Up");
            tankMovement.m_Speed += currentSpeedUp;
            currentSpeedUp = 0;
        }

        if (IsEndEffect())
        {
            tankMovement.m_Speed -= SpeedUp;
            IsStart = true;
            Debug.Log("Stop");
        }
    }

    public override void StartEffect()
    {
        if (IsStart)
        {
            Debug.Log("Start");
            IsStart = false;
            currentSpeedUp = SpeedUp;
            currentEffectTime = effectTime;
        }
    }
}
