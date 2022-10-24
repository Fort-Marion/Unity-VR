using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DetectController : MonoBehaviour
{
    public GameObject XRRig;
    public GameObject NormRig;
    public GameObject XRDeviceSimulator;
    public GameObject Player3D;
    public bool MockHMDOn;

    // Start is called before the first frame update
    void Awake()
    {
        XRDeviceSimulator.SetActive(MockHMDOn);
        
        if(!XRSettings.isDeviceActive && !MockHMDOn)
        {
            Debug.Log("No Headset");
            XRRig.SetActive(false);
            NormRig.SetActive(true);
            Player3D.SetActive(true);
        } 
        else
        {
            Debug.Log("headset detected");
            XRRig.SetActive(true);
            NormRig.SetActive(false);
            Player3D.SetActive(false);
        }
        
    }

    void Update()
    {
        
    }

}
