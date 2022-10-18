using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Localization;
using UnityEngine;

namespace FortMarion
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public TextManager TextManager;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            TextManager = new TextManager();
            TextManager.LoadGameTexts();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
