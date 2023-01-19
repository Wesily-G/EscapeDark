using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Seek : Action
{
    public SharedFloat speed;
    public SharedTransform target;
    public override TaskStatus OnUpdate()
    {
        if (target == null)
            return TaskStatus.Failure;
        transform.forward = Vector3.Lerp(transform.forward, target.Value.position - transform.position,0.5f);
        transform.position = Vector3.MoveTowards(transform.position,target.Value.position,speed.Value*Time.deltaTime);
        if (Vector3.Distance(transform.position, target.Value.position) < 2f)
            return TaskStatus.Failure;
        return TaskStatus.Running;
    }
}
