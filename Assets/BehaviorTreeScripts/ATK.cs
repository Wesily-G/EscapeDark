using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
public class ATK : Action
{
    public SharedTransform target;
    public float AtkCD=3f;
    float countTime;
    public override void OnStart()
    {
        countTime = Time.time;
    }
    public override TaskStatus OnUpdate()
    {
        transform.LookAt(target.Value);
        if (target == null)
            return TaskStatus.Failure;
        if (Time.time >countTime)
            DoAtk();
        return TaskStatus.Running;
    }
    void DoAtk()
    {
        Debug.Log("¹¥»÷");
        countTime = Time.time + AtkCD;
    }
}
