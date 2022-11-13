using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FortMarion
{
    public class SaveRenderTexture : MonoBehaviour
    {
        private bool hasSaved;

        private void Start()
        {
            StartCoroutine(Waiter());
        }
        
        private IEnumerator Waiter()
        {
            yield return new WaitForSeconds(5);
            SaveTexture();
        }
        
        public RenderTexture rt;    
        // Use this for initialization
        public void SaveTexture () {
            byte[] bytes = toTexture2D(rt).EncodeToPNG();
            System.IO.File.WriteAllBytes("D://SavedScreen.png", bytes);
        }
        Texture2D toTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(1028, 1028, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }
    }
}