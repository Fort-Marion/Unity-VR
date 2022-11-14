using UnityEngine;

namespace FortMarion.MainMenu
{
    public class GameMenuToggler : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject MenuGameObject;
        [SerializeField] private float spawnDistance = 10;
        [SerializeField] private float spawnHeight = 0;

        private GameObject activeMenu;

        public void ToggleMenu()
        {
            if (activeMenu != null)
            {
                Destroy(activeMenu);
                return;
            }
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Vector3 heightOffset = new Vector3(0, this.spawnHeight, 0);
            Quaternion playerRotation = player.transform.rotation;
 
            Vector3 spawnPos = playerPos + playerDirection*spawnDistance + heightOffset;
 
            activeMenu = Instantiate(MenuGameObject, spawnPos, playerRotation );
        }
    }
}