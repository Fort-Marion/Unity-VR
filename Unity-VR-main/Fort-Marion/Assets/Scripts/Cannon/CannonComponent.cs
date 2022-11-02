using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FortMarion.Cannon
{
    public class CannonComponent : MonoBehaviour
    {
        public CannonStage Stage { get; set; }

        [SerializeField] private Transform armatureBone;
        [SerializeField] private GameObject cannonballPrefab;
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private GameObject barrelEnd;
        [SerializeField] private GameObject loadedCannonball;
        [SerializeField] private GameObject fireSoundObj;
        [SerializeField] private GameObject indicator;

        public bool _isTestRepeat;
        public bool _isRecentShot;
        private static readonly int Rollback = Animator.StringToHash("Rollback");
        private static readonly int Rollforward = Animator.StringToHash("Rollforward");
        private AudioSource fireSoundSource;
        private GameObject camera;

        private void Awake()
        {
            fireSoundSource = fireSoundObj.GetComponent<AudioSource>();
            // Start with a clean cannon with no wadding/sparks.
            Stage = CannonStage.Load_Cartridge;
            if (Camera.main != null) camera = Camera.main.gameObject;
        }

        private void Start()
        {
            if(_isTestRepeat)
                StartCoroutine(Waiter());
            // else
            //     StartCoroutine(DemoDelayFiring());
        }
        
        private IEnumerator DemoDelayFiring()
        {
            yield return new WaitForSeconds(3);
            Fire();
        }

        private IEnumerator Waiter()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                _isRecentShot = true;
                var position = barrelEnd.transform.position;
                var animator = GetComponent<Animator>();
                var cannonball = Instantiate(cannonballPrefab, position, Quaternion.identity);
                cannonball.GetComponent<Rigidbody>().AddForce(25*armatureBone.up, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(-200*transform.forward, ForceMode.Impulse);
                Instantiate(explosionEffect, position, Quaternion.identity);
                fireSoundSource.Play();
                animator.SetTrigger(Rollback);
                yield return new WaitForSeconds(3);
                animator.SetTrigger(Rollforward);
                _isRecentShot = false; 
            }
        }

        private void Update()
        {
            if (camera != null)
            {
                indicator.transform.LookAt(camera.transform);
            }
        }

        public void RollIntoPosition()
        {
            var animator = GetComponent<Animator>();
            animator.SetTrigger(Rollforward);
            _isRecentShot = false; 
        }

        public void TryFire()
        {
            if(Stage == CannonStage.Linstock_Fire)
                Fire();
        }

        public void Fire()
        {
            _isRecentShot = true;
            var position = barrelEnd.transform.position;
            var animator = GetComponent<Animator>();
            var cannonball = Instantiate(cannonballPrefab, position, Quaternion.identity);
            cannonball.GetComponent<Rigidbody>().AddForce(25*armatureBone.up, ForceMode.Impulse);
            loadedCannonball.SetActive(false);
            GetComponent<Rigidbody>().AddForce(-200*transform.forward, ForceMode.Impulse);
            Instantiate(explosionEffect, position, Quaternion.identity);
            animator.SetTrigger(Rollback);
        }

        // TODO REMOVE THIS (Demo Only)
        public void DemoStageAction()
        {
            switch (Stage)
            {
                case CannonStage.Load_Cartridge:
                    loadedCannonball.SetActive(false);
                    Stage = CannonStage.Linstock_Fire;
                    break;
                case CannonStage.Linstock_Fire:
                    Fire();
                    Stage = CannonStage.Load_Cartridge;
                    break;
            }
        }

        public void NextStage()
        {
            switch (Stage)
            {
                case CannonStage.Worm_Wadding:
                    break;
                case CannonStage.Sponge_Sparks:
                    break;
                case CannonStage.Load_Cartridge:
                    loadedCannonball.SetActive(false);
                    break;
                case CannonStage.Rammer_Push:
                    break;
                case CannonStage.Powder_Prime:
                    break;
                case CannonStage.Linstock_Fire:
                    Fire();
                    break;
            }
            
            Stage = Stage == CannonStage.Linstock_Fire ? CannonStage.Worm_Wadding : Stage + 1;
        }
    }
}
