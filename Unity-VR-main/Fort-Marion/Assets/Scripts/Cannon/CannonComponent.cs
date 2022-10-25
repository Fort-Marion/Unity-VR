using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FortMarion.Cannon
{
    public class CannonComponent : MonoBehaviour
    {
        public CannonStage Stage { get; set; }

        public Transform Armature;
        public GameObject CannonballPrefab;
        public GameObject ExplosionEffect;
        public GameObject BarrelEnd;

        public bool _isRecentShot;
        
        private Vector3? Pos { get; set; } = null;

        private void Awake()
        {
            // Start with a clean cannon with no wadding/sparks.
            Stage = CannonStage.Load_Cartridge;
        }

        private void Start()
        {
            StartCoroutine(Waiter());
        }

        private IEnumerator Waiter()
        {
            yield return new WaitForSeconds(3);
            var position = BarrelEnd.transform.position;
            var cannonball = Instantiate(CannonballPrefab, position, Quaternion.identity);
            var rigid = cannonball.GetComponent<Rigidbody>();
            Pos = cannonball.transform.position;
            _isRecentShot = true;
            cannonball.GetComponent<Rigidbody>().AddForce(25*Armature.up, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(-200*transform.forward, ForceMode.Impulse);
            Instantiate(ExplosionEffect, position, Quaternion.identity);
        }

        private void Update()
        {
        
        }

        public void Fire()
        {
            // TODO Cannon Firing:
            // Get pitch
            // Get gameObject of cannonball loaded
            // Apply force to cannonball of direction relative to cannon ball with variance
            // Generate explosion effect
        }

        public void NextStage()
        {
            Stage = Stage == CannonStage.Linstock_Fire ? CannonStage.Worm_Wadding : Stage + 1;
        }
    }
}
