using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FortMarion.Fort
{
    public class BridgeController : MonoBehaviour
    {
        private Animator animator;
        private static readonly int IsOpen = Animator.StringToHash("isRaised");

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void ToggleBridge()
        {
            var state = animator.GetBool(IsOpen);
            animator.SetBool(IsOpen, !state);
        }
    }
}