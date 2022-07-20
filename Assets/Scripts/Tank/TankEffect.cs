using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEffect : MonoBehaviour
{
    public TankHealth tankHealth;
    public TankMovement tankMovement;
    public TankShooting tankShooting;

    public List<Effect> listEffect;

    private float currentEffectTime;

    private void Update()
    {
        if (listEffect.Count > 0)
        {
            int i = 0;
            while (i < listEffect.Count)
            {
                Debug.Log("Start");
                listEffect[i].StartEffect();
                listEffect[i].DoUpdate(tankHealth, tankMovement, tankShooting);
                if(listEffect[i].IsEndEffect())
                {
                    listEffect.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }

    public void AddEffect(Effect effect)
    {
        Debug.Log("dang ky");
        listEffect.Add(effect);
    }
}
