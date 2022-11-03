using UnityEngine;

namespace FortMarion.Cannon
{
    public class CannonTool : MonoBehaviour
    {
        public CannonToolType ToolType;
        public enum CannonToolType
        {
            None,
            Worm,
            Sponge,
            Rammer,
            Linstock
        }
    }
}