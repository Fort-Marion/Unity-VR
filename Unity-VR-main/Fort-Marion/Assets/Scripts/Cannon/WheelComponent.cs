using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelComponent : MonoBehaviour
{

    private WheelCollider _wheelCollider;
    
    void Start()
    {
        _wheelCollider = GetComponent<WheelCollider>();
    }

    private void FixedUpdate()
    {
        _wheelCollider.motorTorque = 0.00001f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
