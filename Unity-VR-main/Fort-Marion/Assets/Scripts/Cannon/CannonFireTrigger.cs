using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class CannonFireTrigger : MonoBehaviour
{
    private CannonComponent cannonComponent;
    
    private void Awake()
    {
        cannonComponent = gameObject.GetComponentInParent<CannonComponent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<CannonTool>(out var cannonTool)) return;
        if(cannonTool.ToolType == CannonTool.CannonToolType.Linstock && cannonComponent.Stage == CannonStage.Linstock_Fire)
            cannonComponent.NextStage(); // Next Stage handles firing
    }
}
