using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public GameObject vrCam;
    public GameObject normCam;
    // Start is called before the first frame update
    void Start()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        if(inputDevices.Count == 0)
        {
            vrCam.SetActive(false);
            normCam.SetActive(true);
        } 
        else 
        {
            vrCam.SetActive(true);
            normCam.SetActive(false);
        }
    }
}
