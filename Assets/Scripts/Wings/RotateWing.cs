using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWing : MonoBehaviour
{


    public float forwardArcAngle = 10.0f;
    public float timeForBeatforward = 0.2f;
    public Transform pivotTransform;
    public GameObject forwardCube;
    public Vector3 relForward;
    float forwardAngleTravelled = 0f;
    float forwardAngledir = 1f;
    Vector3 relUp;
    public float upArcAngle = 2.0f;
    public float timeForBeatup = 0.1f;
    float upAngleTravelled = 0f;
    float upAngledir = 1f;
    float forwardSpeed;
    float upSpeed;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        forwardSpeed = (forwardArcAngle / timeForBeatforward);
        upSpeed = (upArcAngle / timeForBeatup);
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        relUp = forwardCube.transform.up;
        relForward = -forwardCube.transform.right;
        if (Mathf.Abs(forwardAngleTravelled + forwardAngledir * (forwardSpeed) * Time.deltaTime) >= forwardArcAngle)
        {
            forwardAngledir *= -1;
        }

        forwardAngleTravelled += forwardAngledir * (forwardSpeed) * Time.deltaTime;


        transform.RotateAround(pivotTransform.localPosition, relForward, forwardAngledir * (forwardSpeed) * Time.deltaTime);

        if (Mathf.Abs(upAngleTravelled + upAngledir * (upSpeed) * Time.deltaTime) >= upArcAngle)
        {
            upAngledir *= -1;
        }
       


        upAngleTravelled += upAngledir * (upSpeed) * Time.deltaTime;


        transform.RotateAround(pivotTransform.localPosition, relUp, upAngledir * (upSpeed) * Time.deltaTime);

		if ((startPos - transform.position).magnitude > startPos.magnitude*0.1)
		{
            transform.localPosition = startPos;
		}
    }
}
