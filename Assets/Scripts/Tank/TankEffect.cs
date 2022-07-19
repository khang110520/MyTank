using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEffect : MonoBehaviour
{
    public TankHealth tankHealth;
    public TankMovement tankMovement;
    public TankShooting tankShooting;

    public Effect currentEffect;
    public List<Effect> listEffect;

    private void Awake()
    {
    }

    private void Start()
    {
        currentEffect.StartEffect();
    }

    private void Update()
    {
        if (listEffect.Count > 0)
        {
            foreach (Effect effect in listEffect)
            {
                currentEffect = effect;
                currentEffect.DoUpdate(tankHealth);
                listEffect.Remove(effect);
            }
        }
    }

    public void AddEffect(Effect effect)
    {
        listEffect.Add(effect);
    }
}
