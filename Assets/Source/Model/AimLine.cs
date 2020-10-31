﻿using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    public Transform P1, P2;

    private float LineWidth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //set initial locations
        P1.localPosition = new Vector3(-16.869f, 1,5);
        P2.localPosition = new Vector3(16.99f, 1, 5);      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 V = P2.localPosition - P1.localPosition;
        float len = V.magnitude;

        transform.localPosition = P1.localPosition + 0.5f * V; //sets it in the middle
        transform.localScale = new Vector3(LineWidth, len * 0.5f, LineWidth);
        transform.localRotation = Quaternion.FromToRotation(Vector3.up, V);
    }


    public void MoveToNewPositionR(Vector3 hitpoint) {
        hitpoint.x = 17f;
        //Check if in bound
        if (hitpoint.y > 16.3)
        {
            hitpoint.y = 16.3f;
        }
        else if (hitpoint.y < 1.15)
        {
            hitpoint.y = 1.15f;
        }

        if (hitpoint.z > 22.68)
        {
            hitpoint.z = 22.68f;
        }
        P2.localPosition = hitpoint;
        
    }

    public void MoveToNewPositionL(Vector3 hitpoint)
    {
        hitpoint.x = -17f;
        //Check if in bound
        if (hitpoint.y > 16.3) {
            hitpoint.y = 16.3f; 
        }
        else if (hitpoint.y < 1.15) {
            hitpoint.y = 1.15f;
        }

        if (hitpoint.z > 22.68) {
            hitpoint.z = 22.68f;
        }

        P1.localPosition = hitpoint;
    }
}
