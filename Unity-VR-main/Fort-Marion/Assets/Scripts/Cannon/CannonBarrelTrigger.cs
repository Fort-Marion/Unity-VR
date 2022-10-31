using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class CannonBarrelTrigger : MonoBehaviour
{
    private CannonComponent cannonComponent;

    private void Awake()
    {
        cannonComponent = gameObject.GetComponentInParent<CannonComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag($"Cannonball_6lb")) return;
        if (cannonComponent._isRecentShot || cannonComponent.Stage != CannonStage.Load_Cartridge) return; 
        other.gameObject.SetActive(false);
        LoadCartridge();

    }

    public void LoadCartridge()
    {
        cannonComponent.DemoStageAction(); // TODO Remove demo stuff
    }
}
