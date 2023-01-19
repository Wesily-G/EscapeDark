using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSamItem : InterBase
{
    private void Start()
    {
        addEvent(() => AddSam());
    }
    void AddSam()
    {

        UISam.addSam();
        Destroy(gameObject);
    }
}
