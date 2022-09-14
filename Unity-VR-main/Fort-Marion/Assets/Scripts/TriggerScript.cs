using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] private Transform spawnpoint;

    private void OnTriggerEnter(Collider Spawner)
    {
        objectToBeSpawned.SetActive(true);
        //Instantiate(objectToBeSpawned, spawnpoint.position, Quaternion.identity);
    }
    private void OnTriggerExit(Collider Spawner)
    {
        objectToBeSpawned.SetActive(false);
        objectToBeSpawned.transform.position = new Vector3(-3, 1, -3);
        //Instantiate(objectToBeSpawned, spawnpoint.position, Quaternion.identity);
    }
}
