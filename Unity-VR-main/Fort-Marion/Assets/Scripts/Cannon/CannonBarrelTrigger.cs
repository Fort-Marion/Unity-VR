using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class CannonBarrelTrigger : MonoBehaviour
{
    [SerializeField] private Transform armatureBone;
    private CannonComponent cannonComponent;

    private void Awake()
    {
        cannonComponent = gameObject.GetComponentInParent<CannonComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var objTag = other.tag;
        switch (objTag)
        {
            case "Cannonball_6lb":
                if (cannonComponent._isRecentShot || cannonComponent.Stage != CannonStage.Load_Cartridge) return; 
                other.gameObject.SetActive(false);
                LoadCartridge();
                break;
            case "Cannon_Barrel_Tool":
                SnapTool(other.gameObject);
                break;
            default:
                return;
        }

    }

    public void LoadCartridge()
    {
        cannonComponent.DemoStageAction(); // TODO Remove demo stuff
    }

    public void SnapTool(GameObject tool)
    {
        tool.transform.forward = -armatureBone.up; // Align tool with cannon barrel
    }
}
