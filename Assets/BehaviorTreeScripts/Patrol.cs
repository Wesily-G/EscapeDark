using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Linq;
public class Patrol : Action
{
    public SharedFloat speed;
    
    int indx;
    bool direction;
    public List<Transform> points = new List<Transform>();
    Transform point;
    public int Indx
    {
        get
        {
            return indx;
        }
        set
        {
            if(value>points.Count()-1)
            {
                indx = points.Count() - 1;
            }
            else if(value<=0)
            {
                indx = 0;
            }
            else
            {
                indx = value;
            }
        }
    }
    public override void OnStart()
    {
        float min =float.MaxValue;
        foreach(var a in points)
        {
           if(min>Vector3.Distance(a.position, transform.position))
           {
                min = Vector3.Distance(a.position, transform.position);
                point = a;
                indx = points.IndexOf(a);
           }
        }
        
    }
    public override TaskStatus OnUpdate()
    {
        //Debug.Log("indx:"+Indx);
        //Debug.Log("direction:"+ direction);
        //Debug.Log("pointname:"+point.gameObject.name);
        transform.forward = Vector3.Lerp(transform.forward,point.position-transform.position,0.5f).normalized;//�ı䷽��
        transform.position = Vector3.MoveTowards(transform.position,point.position,speed.Value*Time.deltaTime);//�ƶ�
        if(transform.position==point.position)
        {
            if (Indx >= points.Count() - 1)
            {
                direction = true;
            }
                
            else if(Indx<=0)
            {
                direction = false;
            }
                
            if(!direction)//����
            { 
                point = points[++Indx];
            }
                
            else//����
            {
                point = points[--Indx];
            } 
        }
        return TaskStatus.Running;
    }

}
