using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=15;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey (KeyCode.W))
        {
            transform.Translate(new Vector3(0,0,1)*speed*Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.S))
        {
            transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.A))
        {
            transform.Translate(new Vector3(-1,0,0) * speed * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.D))
        {
            transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime);
        }
    }
}
