using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class Vision : Conditional
{
    public GameObject[] targets;
    public float veiwAngle=90;
    public float veiwDistance=10;
    public SharedTransform target;
    public override void OnStart()
    {
        targets= GameObject.FindGameObjectsWithTag("Player");
    }
    public override TaskStatus OnUpdate()
    {
        if (targets == null)
            return TaskStatus.Failure;
        foreach(var target in targets)
        {
            float distance = Vector3.Distance(target.transform.position,transform.position);
            float angle = Vector3.Angle(transform.forward,target.transform.position-transform.position);
            if(distance<veiwDistance&&angle<veiwAngle/2)
            {
                this.target.Value = target.transform;
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
