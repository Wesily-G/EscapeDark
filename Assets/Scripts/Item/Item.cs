using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public int count;
    public void Delete()
    {
        Destroy(gameObject);
    }

}
