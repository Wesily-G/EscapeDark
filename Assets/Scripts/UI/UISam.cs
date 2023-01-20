using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class UISam : MonoBehaviour
{
    public static UnityAction onSam = delegate { };
    public static UnityAction offSam = delegate { };
    public static UnityAction addSam = delegate { };

    [SerializeField]
    double MaxSam = 100f;
    [SerializeField]
    static double currentSam;
    [SerializeField]
    double SamReducenum = 1f;
    [SerializeField]
    int addsam = 15;
    public Slider samValue;
    private bool isWork = false;
    private void Awake()
    {
        //SamSlider = transform.GetChild(0).GetComponent<Image>();
        currentSam = MaxSam;
    }
    private void Start()
    {
        onSam += () =>SamStartReduce();
        offSam += () =>SamStopReduce();
        addSam += () => AddSam();
        onSam();
    }

    //循环执行状态进行
    private void Update() 
    {
        if (isWork) {
            StartCoroutine(SamReduce(SamReducenum));
            UpdateSam();
        } else
            UpdateSam();

    }

    void SamStartReduce()
    {
        StartCoroutine(SamReduce(SamReducenum));
        isWork = true;
        UpdateSam();
    }

    void SamStopReduce()
    {
        StopCoroutine(SamReduce(SamReducenum));
        isWork = false;
        UpdateSam();
    }

    //更新值的接口
    IEnumerator SamReduce(double reducenum)
    {
        //currentSam -= Time.deltaTime / 3000 * reducenum;
        currentSam -= Time.deltaTime * reducenum;
        Debug.Log("current sam value:"+currentSam);
        yield return null;
    }

    //刷新状态
    void UpdateSam()
    {
        //SamSlider.fillAmount = (float)(MaxSam / currentSam);
        Debug.Log(currentSam / MaxSam);
        samValue.value = (float)(currentSam / MaxSam);
    }

    void AddSam()
    {
        currentSam += addsam;
        UpdateSam();
    }

}
