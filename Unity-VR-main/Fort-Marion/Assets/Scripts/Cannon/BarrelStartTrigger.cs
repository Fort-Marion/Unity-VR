using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class BarrelStartTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<CannonTool>(out var cannonTool)) return;
        Debug.Log("Cannon tool reached start of barrel!");
    }
}
