using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour
{

    Transform target;

    public float speed = 1f;
    public NavMeshAgent agent;

    const float diff = 2f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("GroundCheck").transform;
           
    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(target.position);

    }

    public void Stop()
    {
        agent.isStopped = true; 
    }

}
