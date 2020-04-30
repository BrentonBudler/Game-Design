using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    public float speed = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = this.transform.localRotation.eulerAngles.x;
        if (xRot <= 30f)
        {
            transform.Rotate(speed, 0, 0);
        }
        
       
    
        
        
    }
}
