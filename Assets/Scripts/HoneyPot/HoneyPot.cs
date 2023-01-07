using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPot : MonoBehaviour
{
    public BeeHive beehive;

    public int honeyCount=0;
    public int maxHoney = 9;
    public GameObject honey; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(honeyCount==0 && beehive.numPollen > 0)
		{
            honey.SetActive(true);
        }

        honeyCount = beehive.numPollen;
		if (honeyCount == 0)
		{
            honey.SetActive(false);
        }

        honey.transform.localScale = new Vector3(.9f, honeyCount / 10.0f, 0.9f);
    }
}
