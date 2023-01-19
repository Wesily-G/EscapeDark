using FogOfWar;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //以前  当前  开灯的光照范围
    int lightsize;
    [SerializeField]
    int currentSize;
    [SerializeField]
    int OpenLightSize = 12;

    bool OpenLight;

    private void Start()
    {
        OpenLight = false;

        lightsize = transform.Find("Player").GetComponent<FowViewer>().viewerRange;
        currentSize = lightsize;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (OpenLight)
            {
                currentSize = OpenLightSize;
                OpenLight = false;
                StartCoroutine(onOpenLight());
                StopCoroutine(disOpenLight());
            }
            else
            {
                currentSize = lightsize;
                OpenLight = true;
                StartCoroutine(disOpenLight());
                StopCoroutine(onOpenLight());
            }
        }
    }

    IEnumerator onOpenLight()
    {
        while(OpenLight)
        {
            UILight.onLight();
            UISam.offSam();
        }
        yield return null;
    }

    IEnumerator disOpenLight()
    {
        while(OpenLight == false)
        {
            UILight.offLight();
            UISam.onSam();
        }
        yield return null;
    }
}
