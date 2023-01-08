using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour
{

    public GameObject Bee;
    public GameObject pollenPrefab;
    public int numPollen = 0;
    public GameObject HoneyJar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {


        Debug.Log("Pollened");
        if (other.CompareTag("Bee"))
		{
            foreach (Transform child in other.transform)
			{
				if (child.CompareTag("Stuck"))
				{
                    numPollen++;
                    Destroy(child.gameObject);
                    
				}
			}
    
		}
    }
}
