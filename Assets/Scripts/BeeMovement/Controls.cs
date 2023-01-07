using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Camera cam;

    Rigidbody m_Rigidbody;
    public float m_Speed= 10.0f;
    float rotationSpeed = 50f;
    float force;
    public GameObject forwardCube;
    Vector3 relforward;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        


        force = 1f;
    }

    // Update is called once per frame
    void Update()
    {



        relforward = -forwardCube.transform.right;


        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 forcedir = relforward *400+ new Vector3(0, 400, 0);
            m_Rigidbody.AddForce(forcedir);
        }



        float rotationUD = Input.GetAxis("Vertical") * rotationSpeed;
        float rotationLR = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        rotationUD *= Time.deltaTime;
        rotationLR *= Time.deltaTime;

        // Move translation along the object's z-axis


        // Rotate around our y-axis

        
        transform.Rotate(0, 0, -rotationUD);
        //cam.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, rotationUD);
        transform.Rotate(0, rotationLR, 0, Space.World) ;
        
            
        //Debug.DrawLine(transform.position, transform.position + 100*relforward, Color.white, 2.5f);

    }
}
