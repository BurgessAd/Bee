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
    private bool walking = false;
    private bool attacking = false;
    // private Enum state {Walk, Attack, Sleep}
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(bee.transform.position, bear.transform.position);
        
        if (dist < 1 && walking){
            walking=false;
            Debug.Log("Attack " + dist.ToString(".0"));
            attack();
        }
        else if (!walking){
            Debug.Log("Walk");
            walkHere(bee.transform.position);
            walking=true;
            }
        // Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip);
    }

    public void walkHere(Vector3 pos){
        agent.SetDestination(pos);
        // anim.ResetTrigger("Attack1");
        // anim.ResetTrigger("Attack2");
        // anim.ResetTrigger("Attack3");
        // anim.ResetTrigger("Attack5");
        anim.SetTrigger("WalkForward");
    }

    public void attack(){
        // anim.ResetTrigger("WalkForward");
        string[] attacks = {"Attack1", "Attack2", "Attack3", "Attack5"};
        string attack = attacks[Random.Range(0,3)];
        // Debug.Log(attack);
        anim.SetTrigger(attack);
        // agent.ResetPath();
    }
}
