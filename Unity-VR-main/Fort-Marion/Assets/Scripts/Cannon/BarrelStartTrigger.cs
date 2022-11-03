using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class BarrelStartTrigger : MonoBehaviour
{
    private CannonComponent cannonComponent;
    
    private void Awake()
    {
        cannonComponent = gameObject.GetComponentInParent<CannonComponent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<CannonTool>(out var cannonTool)) return;
        switch (cannonTool.ToolType)
        {
            case CannonTool.CannonToolType.Worm:
                if(cannonComponent.Stage == CannonStage.Worm_Wadding)
                    cannonComponent.NextStage();
                break;
            case CannonTool.CannonToolType.Sponge:
                if(cannonComponent.Stage == CannonStage.Sponge_Sparks)
                    cannonComponent.NextStage();
                break;
            case CannonTool.CannonToolType.Rammer:
                if(cannonComponent.Stage == CannonStage.Rammer_Push)
                    cannonComponent.NextStage();
                break;
            
            // Not used by this component:
            case CannonTool.CannonToolType.None:
                break;
            case CannonTool.CannonToolType.Linstock:
                break;
            default:
                return;
        }
    }
}
