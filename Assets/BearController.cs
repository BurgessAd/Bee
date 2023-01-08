using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject bee;
    public Animator anim;
    public GameObject bear;
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(bee.transform.position, bear.transform.position);
        
        if (dist < 1){
            attack();
        }
        else{
            walkHere(bee.transform.position);
            }
    }

    public void walkHere(Vector3 pos){
        agent.SetDestination(pos);
        anim.SetTrigger("WalkForward");
    }

    public void attack(){
        string[] attacks = {"Attack1", "Attack2", "Attack3", "Attack5"};
        string attack = attacks[Random.Range(0,3)];
        // Debug.Log(attack);
        anim.SetTrigger(attack);
        agent.ResetPath();
    }
}
