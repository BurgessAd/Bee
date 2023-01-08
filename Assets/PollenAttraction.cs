using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PollenAttraction : MonoBehaviour
{
    public float forceFactor = 1f;

    List<Rigidbody> rgBalls = new List<Rigidbody>();

    public GameObject bee;

    void Start()
    {
    }

    private void FixedUpdate() {
        foreach (Rigidbody rgBall in rgBalls)
        {   
            float dist = Vector3.Distance(bee.transform.position, rgBall.position);
            float strength = 1/Mathf.Pow(dist,2f);
            Vector3 direction = bee.transform.position - rgBall.position;
            rgBall.AddForce(strength * direction * forceFactor * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit");
        // Add magneteism
        if(other.CompareTag("Pollen")){
            Debug.Log("Magnet");
            rgBalls.Add(other.GetComponent<Rigidbody>());
            other.tag="Magnetism";
            return;
        }
        
        // make sticky
        if(other.CompareTag("Magnetism")){
            Debug.Log("Stuck");
            rgBalls.Remove(other.GetComponent<Rigidbody>());
            other.transform.parent = bee.transform;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().isKinematic =true;
            other.GetComponent<Rigidbody>().useGravity  = false;
            foreach (Collider collider in other.GetComponent<Rigidbody>().GetComponents<Collider>())
            {
                collider.enabled=false;
            }
            

            other.tag="Stuck";
            return;
        }
        if(other.CompareTag("Bear")){
            Debug.Log("Game Over");
            return;
        }
        Debug.Log(other.tag);
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Magnetism")){
            rgBalls.Remove(other.GetComponent<Rigidbody>());
            other.tag="Pollen";
            Debug.Log("Exit");
            return;
            // other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            // other.GetComponent<Rigidbody>().isKinematic =false;
        }
    }
}