using UnityEngine;

namespace FortMarion.MainMenu
{
    public class GameMenuToggler : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject menuGameObject;
        [SerializeField] private float spawnDistance = 10;
        [SerializeField] private float spawnHeight = 0;
        

        private bool isActiveMenu;

        public void ToggleMenu()
        {
            if (isActiveMenu)
            {
                menuGameObject.transform.position = new Vector3(0, -100, 0);
                isActiveMenu = false;
                return;
            }
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Vector3 heightOffset = new Vector3(0, this.spawnHeight, 0);
            Quaternion playerRotation = player.transform.rotation;
 
            Vector3 spawnPos = playerPos + playerDirection*spawnDistance + heightOffset;

            menuGameObject.transform.position = spawnPos;
            menuGameObject.transform.rotation = playerRotation;
            isActiveMenu = true;
        }
    }
}