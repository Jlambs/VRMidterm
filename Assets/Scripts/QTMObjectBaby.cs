﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTMRealTimeSDK;
using QualisysRealTime.Unity;

// This class applies the transform data supplied by qualisys of the given ID to the transform of this object
public class QTMObjectBaby : MonoBehaviour
{
    public string objectName; // Name of the object as registered in the Qualisys system
    private RTClient rtClient;

    public GameObject babyMover;

    void Start()
    {
        // Get a reference to the global Qualisys client object
        rtClient = RTClient.GetInstance();
    }

    void Update()
    {
        // Check if the system is currently streaming
        if (rtClient.GetStreamingStatus())
        {
            // Get the data of the tracked object based on the name supplied
            SixDOFBody trackedObj = rtClient.GetBody(objectName);

            bool isTrolling = babyMover.GetComponent<BabyMover>().isTrolling;

            // If this object has a position value, that means it's tracked!
            if (!float.IsNaN(trackedObj.Position.sqrMagnitude) && !isTrolling)
            {
                // Apply the position and rotation to the object
                transform.position = trackedObj.Position + new Vector3(0, 1, 0);
                transform.rotation = trackedObj.Rotation;
            }
        }
    }
}