using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    Transform target;

    public float speed = 1f;

    const float diff = 2f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("GroundCheck").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
        if ((transform.position - target.position).magnitude > diff)
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }
    }

    public void Stop()
    {
        speed = 0f;
    }
}
