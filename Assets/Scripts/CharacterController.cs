using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    Rigidbody rig;
    public float speed = 5;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {

        Movent();


    }
    private void Movent()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        //Debug.Log(ver);
        rig.velocity = new Vector3(hor,0, ver) * Time.deltaTime * speed;
    }

}

