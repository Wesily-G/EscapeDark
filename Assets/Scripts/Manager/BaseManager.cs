using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T instance;
    public static T GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this as T;
    }

}
