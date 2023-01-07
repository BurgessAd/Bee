using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed= 10.0f;
    float rotationSpeed;
    float force;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
       
        rotationSpeed = 20.0f;
        force = 1f;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Vector3.Dot(m_Rigidbody.velocity, -transform.right) <= m_Speed)
		{
            m_Rigidbody.AddForce(-transform.right * force);
        }

        if(Input.GetButtonDown("Fire1"))
		{
            m_Rigidbody.AddForce(0,0,10);
        }


       
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
