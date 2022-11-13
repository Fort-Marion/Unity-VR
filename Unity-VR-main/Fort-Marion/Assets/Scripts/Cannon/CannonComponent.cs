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
        [SerializeField] private GameObject indicatorsGameObject;
        [SerializeField] private GameObject blocksGameObject;
        [SerializeField] private GameObject pushTriggerBack;
        [SerializeField] private GameObject pushTriggerFront;

        public bool _isTestRepeat;
        private static readonly int Rollback = Animator.StringToHash("Rollback");
        private static readonly int Rollforward = Animator.StringToHash("Rollforward");
        private static readonly int RollbackPush = Animator.StringToHash("Rollback_Push");
        private AudioSource fireSoundSource;
        private GameObject camera;
        private byte pitch;
        

        private void Awake()
        {
            fireSoundSource = fireSoundObj.GetComponent<AudioSource>();
            // Start with a clean cannon with no wadding/sparks.
            Stage = CannonStage.Initial;
            if (Camera.main != null) camera = Camera.main.gameObject;
        }

        private void Start()
        {
            if(_isTestRepeat)
                StartCoroutine(Waiter());
        }

        private IEnumerator Waiter()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
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
            }
        }

        private void Update()
        {
            if (camera != null)
            {
                foreach(Transform childTransform in indicatorsGameObject.transform)
                    childTransform.LookAt(camera.transform);
            }
        }

        public void RollForward()
        {
            var animator = GetComponent<Animator>();
            animator.SetTrigger(Rollforward);
            pushTriggerBack.SetActive(false);
        }
        
        public void RollBackwardsPush()
        {
            var animator = GetComponent<Animator>();
            animator.SetTrigger(RollbackPush);
            pushTriggerFront.SetActive(false);
            NextStage();
        }

        public void TryFire()
        {
            if(Stage == CannonStage.Linstock_Fire)
                Fire();
        }

        public void Fire()
        {
            var position = barrelEnd.transform.position;
            var animator = GetComponent<Animator>();
            var cannonball = Instantiate(cannonballPrefab, position, Quaternion.identity);
            cannonball.GetComponent<Rigidbody>().AddForce(25*armatureBone.up, ForceMode.Impulse);
            loadedCannonball.SetActive(false);
            GetComponent<Rigidbody>().AddForce(-200*transform.forward, ForceMode.Impulse);
            Instantiate(explosionEffect, position, Quaternion.identity);
            fireSoundSource.Play();
            animator.SetTrigger(Rollback);
        }

        private void UpdateIndicatorIcons(bool initial = false)
        {
            // Get transforms
            var arrowTransform = indicatorsGameObject.transform.GetChild(0);
            var activeToolTransform = indicatorsGameObject.transform.GetChild(Stage == CannonStage.Worm_Wadding ? (int) CannonStage.Linstock_Fire : (int) Stage - 1);
            
            var nextToolTransform = indicatorsGameObject.transform.GetChild((int) Stage);
            var offset = activeToolTransform.localPosition.y - arrowTransform.localPosition.y;
            
            // Update active tool and arrow position if needed.
            activeToolTransform.gameObject.SetActive(false);
            nextToolTransform.gameObject.SetActive(true);

            if (initial) return;
            var localPosition = nextToolTransform.localPosition;
            arrowTransform.localPosition = new Vector3(localPosition.x, localPosition.y - offset, localPosition.z);
        }

        public void ChangePitch()
        {
            Vector3 rot = new Vector3(0,0,0);
            var block0 = blocksGameObject.transform.GetChild(0).gameObject;
            var block1 = blocksGameObject.transform.GetChild(1).gameObject;
            switch (pitch)
            {
                case 0:
                    rot.x = 175.2f;
                    armatureBone.localEulerAngles = rot;
                    block0.SetActive(true);
                    block1.SetActive(false);
                    pitch++;
                    break;
                case 1:
                    rot.x = 178.7f;
                    armatureBone.localEulerAngles = rot;
                    block0.SetActive(true);
                    block1.SetActive(true);
                    pitch++;
                    break;
                case 2:
                    rot.x = 172.0f;
                    armatureBone.localEulerAngles = rot;
                    block0.SetActive(false);
                    block1.SetActive(false);
                    pitch = 0;
                    break;
            }
        }
        
        public void NextStage()
        {
            switch (Stage)
            {
                case CannonStage.Initial:
                    indicatorsGameObject.SetActive(true);
                    Stage = CannonStage.Worm_Wadding;
                    UpdateIndicatorIcons(true);
                    return;
                case CannonStage.Worm_Wadding:
                    break;
                case CannonStage.Sponge_Sparks:
                    break;
                case CannonStage.Load_Cartridge:
                    loadedCannonball.SetActive(true);
                    break;
                case CannonStage.Rammer_Push:
                    pushTriggerBack.SetActive(true);
                    indicatorsGameObject.SetActive(false);
                    break;
                case CannonStage.Roll_Into_Position:
                    RollForward();
                    indicatorsGameObject.SetActive(true);
                    break;
                case CannonStage.Linstock_Fire:
                    loadedCannonball.SetActive(false);
                    Fire();
                    break;
            }
            Stage = Stage == CannonStage.Linstock_Fire ? CannonStage.Worm_Wadding : Stage + 1;
            UpdateIndicatorIcons();
        }
    }
}
