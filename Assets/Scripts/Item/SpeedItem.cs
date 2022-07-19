using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/SpeedItem")]
public class SpeedItem : ItemEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<TankMovement>().m_Speed += amount;
    }
}
