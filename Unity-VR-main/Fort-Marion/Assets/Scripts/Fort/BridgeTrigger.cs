using System;
using UnityEngine;

namespace FortMarion.Fort
{
    public class BridgeTrigger : MonoBehaviour
    {
        public GameObject BridgeObject;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag($"Player")) return;
            BridgeObject.GetComponent<BridgeController>().Open();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag($"Player")) return;
            BridgeObject.GetComponent<BridgeController>().Close();
        }
    }
}