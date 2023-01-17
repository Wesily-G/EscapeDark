using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterBase : MonoBehaviour
{
    public UnityEvent unityEvent;
    public bool clearEvent;
    public int Index=0;
    public void Execution()
    {
        unityEvent.Invoke();
        if (clearEvent)
        {
            unityEvent.RemoveAllListeners();
        }
    }
    public void addEvent(UnityAction action)
    {
        unityEvent.AddListener(action);
    }
}
