using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLightItem : InterBase
{
    private void Start()
    {
        addEvent(() => AddLight());
    }
    void AddLight()
    {
        UILight.addLight();
        Destroy(gameObject);
    }
}
