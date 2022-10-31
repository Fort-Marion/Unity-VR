using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class CannonPushTrigger : MonoBehaviour
{
    private CannonComponent cannonComponent;

    private void Awake()
    {
        cannonComponent = gameObject.GetComponentInParent<CannonComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag($"Player")) return;
        if(cannonComponent._isRecentShot)
            cannonComponent.RollIntoPosition();
    }
}
