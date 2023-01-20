using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rig;
    public float speed = 5;
    public Transform hand;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        Movent();
        PointMouse();

    }
    private void Movent()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetFloat("Aix",Mathf.Abs((hor+ver))/2);
        //Debug.Log(ver);
        rig.velocity = new Vector3(hor,0, -ver) * Time.deltaTime * speed;
    }
    public void PointMouse()
    {
        float mousePoint_Y;
        float screen_Y;
        screen_Y = Screen.height;
        if (Input.mousePosition.y>0&& Input.mousePosition.y< Screen.height)
        {
            mousePoint_Y = Input.mousePosition.y;
            hand.localRotation = Quaternion.Euler(0, 0, -((mousePoint_Y / screen_Y) * 180-180));

        }
        if (Input.mousePosition.x > Screen.width/2)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (Input.mousePosition.x < Screen.width / 2)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }

    }

}

