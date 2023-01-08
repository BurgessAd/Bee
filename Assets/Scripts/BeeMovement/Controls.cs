using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Camera cam;

    Rigidbody m_Rigidbody;
    public float m_Speed= 1.0f;
    public float rotationSpeed = 50f;
    Vector3 force;
    public GameObject forwardCube;
    Vector3 relforward;
    public float forwardForce = 400;
    public float upwardForce = 400;
    public float defaultDrag = 1.5f;
    public float stoppingDrag = 6;
    public float scalingRange = 0.1f;
    public float timeOfScale = 0.1f;
    public float speedOfScale;
    public int scaleDir = 1;
    float distToGround;
    Vector3 relRight;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        speedOfScale = scalingRange / timeOfScale;
        distToGround = GetComponent<SphereCollider>().bounds.extents.y;

       
    }


    private bool IsGrounded()
	{
        //Debug.DrawLine(transform.position, transform.position - Vector3.up*(distToGround+0.013f), Color.white, 0f);
        return Physics.Raycast(transform.position, -Vector3.up, distToGround+0.013f);
	}

    public void OnControlsEnabled() 
    {
        enabled = true;
    }

    public void OnControlsDisabled() 
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.localScale.x>=1)
		{
            scaleDir = -1;
		}
        else if (transform.localScale.x <= 1 - scalingRange)
		{
            scaleDir = 1;
		}
        transform.localScale += Vector3.one*speedOfScale * Time.deltaTime*scaleDir;
        





        relforward = -forwardCube.transform.right;
        relRight = forwardCube.transform.forward;

        if (Input.GetButtonDown("Fire1"))
        {
            force = (relforward *forwardForce+ new Vector3(0, upwardForce, 0))*Input.GetAxis("Fire1");
            m_Rigidbody.AddForce(force);
        }

        if (Input.GetButtonUp("Fire2"))
        {
            m_Rigidbody.drag = defaultDrag;
        }

        float angle = Vector3.Angle(relforward, Vector3.up);

        if (IsGrounded())
		{
            
            Vector3 vel_f = Input.GetAxis("Vertical") * m_Speed*relforward;

            Vector3 temp = m_Rigidbody.velocity;
            m_Rigidbody.velocity = new Vector3(vel_f.x, temp.y, vel_f.z);

        }
        else
		{
            if (Input.GetButtonDown("Fire2"))
            {
                m_Rigidbody.drag = stoppingDrag;
            }
			



            float rotationUD = Input.GetAxis("Vertical") * rotationSpeed;
           

            // Make it move 10 meters per second instead of 10 meters per frame...
            rotationUD *= Time.deltaTime;
            

            // Move translation along the object's z-axis


            // Rotate around our y-axis

            if (angle - rotationUD >= 60 && angle - rotationUD <= 120)
            {
                transform.Rotate(0, 0, -rotationUD);
            }
            //cam.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, rotationUD);
            
        }
        
        float rotationLR = Input.GetAxis("Horizontal") * rotationSpeed;
        rotationLR *= Time.deltaTime;
        transform.Rotate(0, rotationLR, 0, Space.World);


        //Debug.DrawLine(transform.position, transform.position + 100*relforward, Color.white, 2.5f);

    }
}
