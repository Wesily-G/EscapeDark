using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public int count;
    private BoxCollider boxCollider;

    public void Start()
    {
        
    }
    public void Delete()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("destroy");
        Delete();
    }
}
