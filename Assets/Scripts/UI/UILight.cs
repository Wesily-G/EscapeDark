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
    Image LightSlider;
    private void Awake()
    {
        LightSlider = transform.GetChild(0).GetComponent<Image>();
        currentLight = MaxLight;
    }
    private void Start()
    {
        onLight += () => LightStartReduce();
        offLight += () => LightStopReduce();
        addLight += () => AddLight();
    }

    void LightStartReduce()
    {
        StartCoroutine(SamReduce(LightReducenum));
        UpdateLight();
    }

    void LightStopReduce()
    {
        StopCoroutine(SamReduce(LightReducenum));
    }
    IEnumerator SamReduce(double reducenum)
    {
        currentLight -= Time.deltaTime / 3000 * reducenum;
        yield return null;
    }

    void UpdateLight()
    {
        LightSlider.fillAmount = (float)(MaxLight / currentLight);
    }

    void AddLight()
    {
        currentLight += addlight;
        UpdateLight();
    }
}
