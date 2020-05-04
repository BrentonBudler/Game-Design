﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour
{

    public Transform target;

    public float speed = 1f;
    public NavMeshAgent agent;
    public bool follow = true; 

    const float diff = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow == true)
        {
            agent.SetDestination(target.position);
        }
    }

    public void Stop()
    {
        follow = false; 
    }
}
