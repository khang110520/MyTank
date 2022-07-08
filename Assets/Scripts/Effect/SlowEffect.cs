using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    private TankMovement tankMovement;

    private void OnTriggerEnter(Collider other)
    {
        tankMovement = other.GetComponent<TankMovement>();
        tankMovement.m_Speed -= 9;
    }
}
