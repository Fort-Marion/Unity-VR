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
        private static readonly int Rollback = Animator.StringToHash("Rollback");
        private static readonly int Rollforward = Animator.StringToHash("Rollforward");

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
            while (true)
            {
                yield return new WaitForSeconds(3);
                _isRecentShot = true;
                var position = BarrelEnd.transform.position;
                var animator = GetComponent<Animator>();
                var cannonball = Instantiate(CannonballPrefab, position, Quaternion.identity);
                cannonball.GetComponent<Rigidbody>().AddForce(25*Armature.up, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(-200*transform.forward, ForceMode.Impulse);
                Instantiate(ExplosionEffect, position, Quaternion.identity);
                animator.SetTrigger(Rollback);
                yield return new WaitForSeconds(3);
                animator.SetTrigger(Rollforward);
                _isRecentShot = false; 
            }
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
