using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/SpeedDownEffeect")]
public class SpeedDownEffeect : Effect
{
    public float SpeedDown;
    private float currentSpeedDown;

    public override void DoUpdate(TankHealth targetHealth, TankMovement tankMovement, TankShooting tankShooting)
    {
        currentEffectTime -= Time.deltaTime;
        Debug.Log(tankMovement.m_Speed);
        if (!IsEndEffect())
        {
            Debug.Log("Up");
            tankMovement.m_Speed -= currentSpeedDown;
            currentSpeedDown = 0;
        }

        if (IsEndEffect())
        {
            tankMovement.m_Speed += SpeedDown;
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
            currentSpeedDown = SpeedDown;
            currentEffectTime = effectTime;
        }
    }
}
