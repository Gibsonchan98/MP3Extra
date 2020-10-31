using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLine : MonoBehaviour
{
    public Transform P1, P2;

    private float LineWidth = 3f; //radius 1.5
    // Start is called before the first frame update
    void Start()
    {
        //set initial locations
        P1.localPosition = new Vector3(-5f, 0, 14.75f); //back
        P2.localPosition = new Vector3(-11.05f, -4.8f, 2); //floor
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

    //move Back Endpoint
    public void MoveToNewPositionB(Vector3 hitpoint)
    {
        hitpoint.z = 14.75f; //always stay on back wall
        //Check if in bound
        if (hitpoint.y > 10.98f)
        {
            hitpoint.y = 10.98f;
        }
        else if (hitpoint.y < -3.91f)
        {
            hitpoint.y = -3.91f;
        }

        if (hitpoint.x > 14.56f)
        {
            hitpoint.x = 14.56f;
        }
        else if (hitpoint.x < -17.22f) {
            hitpoint.x = -17.22f;
        }
        P1.localPosition = hitpoint;

    }

    //move Floor Endpoint
    public void MoveToNewPositionF(Vector3 hitpoint)
    {
        //always stay on floor
        hitpoint.y = -4.8f;
        //Check if in bound
        if (hitpoint.x > 14.61f)
        {
            hitpoint.x = 14.61f;
        }
        else if (hitpoint.x < -10f)
        {
            hitpoint.x = -10f;
        }

        else if (hitpoint.z > 13.58f)
        {
            hitpoint.z = 13.98f;
        }
        else if (hitpoint.z < -13f)
        {
            hitpoint.z = -13f;
        }


        P2.localPosition = hitpoint;
    }
}
