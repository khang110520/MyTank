using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Effect currentEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank")
        {
            other.GetComponent<TankEffect>().AddEffect(currentEffect);
        }
        Destroy(gameObject);
    }
}
