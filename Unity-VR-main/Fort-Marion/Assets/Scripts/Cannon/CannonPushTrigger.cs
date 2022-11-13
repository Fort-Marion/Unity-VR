using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class CannonPushTrigger : MonoBehaviour
{
    
    [SerializeField] private bool isFront;
    private CannonComponent cannonComponent;

    private void Awake()
    {
        cannonComponent = gameObject.GetComponentInParent<CannonComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag($"Player")) return;
        if(isFront && cannonComponent.Stage == CannonStage.Initial)
            cannonComponent.RollBackwardsPush();
        else if(cannonComponent.Stage == CannonStage.Roll_Into_Position)
            cannonComponent.NextStage(); // will roll forward
    }
}
