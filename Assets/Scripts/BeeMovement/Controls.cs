using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_Speed;
    float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 10.0f;
        rotationSpeed = 20.0f;    
    }
    
    // Update is called once per frame
    void Update()
    {

        m_Rigidbody.velocity = -transform.right * m_Speed;


       
            float rotationUD = Input.GetAxis("Vertical") * rotationSpeed;
            float rotationLR = Input.GetAxis("Horizontal") * rotationSpeed;

            // Make it move 10 meters per second instead of 10 meters per frame...
            rotationUD *= Time.deltaTime;
            rotationLR *= Time.deltaTime;
       
            // Move translation along the object's z-axis
            

            // Rotate around our y-axis
            transform.Rotate(new Vector3(0, rotationLR ,rotationUD));
        
    }
}
