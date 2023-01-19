using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : InterBase
{
    [SerializeField]
    float rotatingTime =15f;
    UnityAction DoorOpen;
    private void Start()
    {
        //float moveRotationAngle = 90;
        //Rotating(moveRotationAngle);;
    }
    private void OnTriggerEnter(Collider other)
    {
        //旋转角度
        float moveRotationAngle = 90;
        if (other.tag == "Player")
        {
            Debug.Log("门打开");
            addEvent(() => Rotating(moveRotationAngle));
        }
    }

    void Rotating(float RotationAngle)
    {
        Quaternion moveRotation = Quaternion.AngleAxis(RotationAngle, Vector3.up);
        StartCoroutine(RotateDoor(moveRotation));
    }

    IEnumerator RotateDoor(Quaternion moveRotation)
    {
        float t = 0f;
        while (t < rotatingTime)
        {
            t += Time.fixedDeltaTime / rotatingTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, moveRotation, t / rotatingTime);
            yield return null;
        }
    }
}
