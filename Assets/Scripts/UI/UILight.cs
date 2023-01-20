using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UILight : MonoBehaviour
{
    public UnityAction onSam = delegate { };
    public UnityAction offSam = delegate { };

    [SerializeField]
    double MaxSam = 100f;
    [SerializeField]
    double currentSam;
    [SerializeField]
    double SamReducenum = 1f;
    Image SamSlider;
    private void Awake()
    {
        SamSlider = transform.GetChild(0).GetComponent<Image>();
        currentSam = MaxSam;
    }
    private void Start()
    {
        onSam += () => SamStartReduce();
        offSam += () => SamStopReduce();
    }

    void SamStartReduce()
    {
        StartCoroutine(SamReduce(SamReducenum));
        SamSlider.fillAmount = (float)(MaxSam / currentSam);
    }

    void SamStopReduce()
    {
        StopCoroutine(SamReduce(SamReducenum));
    }
    IEnumerator SamReduce(double reducenum)
    {
        currentSam -= Time.deltaTime / 3000 * reducenum;
        yield return null;
    }
}
