using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPot : MonoBehaviour
{
    public BeeHive beehive;
    public GameObject Bear; 
    public int honeyCount=0;
    public int maxHoney = 50;
    public GameObject honey;
    public float starty;
    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        starty = honey.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(honeyCount==0 && beehive.numPollen > 0)
		{
            Bear.GetComponent<BearController>().AwakenFromHisEternalSlumber();
            //Debug.Log("Beeps");
            honey.SetActive(true);
            uiManager.BearWarning();
            maxHoney = maxHoney + beehive.numPollen;
        }



        honeyCount = beehive.numPollen;

		if (honeyCount == 0)
		{
            honey.SetActive(false);
        }
		if (honeyCount >= maxHoney)
		{
            uiManager.OnWinGame();
		}


        honey.transform.localScale = new Vector3(honey.transform.localScale.x, 0.65f* honeyCount / (maxHoney+1.0f), honey.transform.localScale.z);
        Vector3 temp = honey.transform.localPosition;
        honey.transform.localPosition = new Vector3(temp.x,  starty + 0.65f * honeyCount / (maxHoney + 1.0f), temp.z);


    }
}
