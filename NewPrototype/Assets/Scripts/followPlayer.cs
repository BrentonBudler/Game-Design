using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour
{

    public Transform target;

    public float speed = 1f;
    public NavMeshAgent agent;

    const float diff = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        /*
        transform.LookAt(target.position);
        if ((transform.position-target.position).magnitude > diff)
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }
        */
    }
}
