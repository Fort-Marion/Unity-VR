using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FortMarion.Fort
{
    public class BridgeController : MonoBehaviour
    {
        private Animator animator;
        private static readonly int IsRaised = Animator.StringToHash("isRaised");

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void ToggleBridge()
        {
            var state = animator.GetBool(IsRaised);
            animator.SetBool(IsRaised, !state);
        }
        
        public void Open()
        {
            animator.SetBool(IsRaised, false);
        }
        
        public void Close()
        {
            animator.SetBool(IsRaised, true);
        }
    }
}