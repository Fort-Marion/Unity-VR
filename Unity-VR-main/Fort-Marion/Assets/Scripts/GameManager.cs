using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Localization;
using UnityEngine;

namespace FortMarion
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("GameManager Instance is Null!");
                return _instance;
            }
        }
        public TextManager TextManager;
        public EControllerType ControllerType { get; set; }

        private void Awake()
        {
            _instance = this;
            TextManager = new TextManager();
            TextManager.LoadGameTexts();
        }
        
        void Start()
        {
        }

        void Update()
        {
        }

        public enum EControllerType
        {
            None,
            Desktop,
            VR
        }
    }
}
