using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemEffect itemEffect;

    private void OnTriggerEnter(Collider other)
    {
        //check player

        Destroy(gameObject);
        itemEffect.Apply(other.gameObject);
    }
}
