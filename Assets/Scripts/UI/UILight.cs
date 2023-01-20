using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UILight : MonoBehaviour
{
    public static UnityAction onLight = delegate { };
    public static UnityAction offLight = delegate { };
    public static UnityAction addLight = delegate { };
    [SerializeField]
    double MaxLight = 100f;
    [SerializeField]
    static double currentLight;
    [SerializeField]
    double LightReducenum = 1f;
    [SerializeField]
    int addlight = 15;
    public Slider samValue;
    private bool isWork = false;
    private void Awake() {
        //SamSlider = transform.GetChild(0).GetComponent<Image>();
        currentLight = MaxLight;
    }
    private void Start() {
        onLight += () => SamStartReduce();
        offLight += () => SamStopReduce();
        addLight += () => AddLight();
        onLight();
    }

    //循环执行状态进行
    private void Update() {
        if (isWork) {
            StartCoroutine(LightReduce(LightReducenum));
            UpdateLight();
        } else
            UpdateLight();

    }

    void SamStartReduce() {
        StartCoroutine(LightReduce(LightReducenum));
        isWork = true;
        UpdateLight();
    }

    void SamStopReduce() {
        StopCoroutine(LightReduce(LightReducenum));
        isWork = false;
        UpdateLight();
    }

    //更新值的接口
    IEnumerator LightReduce(double reducenum) {
        //currentSam -= Time.deltaTime / 3000 * reducenum;
        currentLight -= Time.deltaTime * reducenum;
        Debug.Log("current light value:" + currentLight);
        yield return null;
    }

    //刷新状态
    void UpdateLight() {
        //SamSlider.fillAmount = (float)(MaxSam / currentSam);
        Debug.Log(currentLight / MaxLight);
        samValue.value = (float)(currentLight / MaxLight);
    }

    void AddLight() {
        currentLight += addlight;
        UpdateLight();
    }
}
