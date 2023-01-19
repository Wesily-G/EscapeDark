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
    Image SamSlider;
    private void Awake()
    {
        SamSlider = transform.GetChild(0).GetComponent<Image>();
        currentSam = MaxSam;
    }
    private void Start()
    {
        onSam += () =>SamStartReduce();
        offSam += () =>SamStopReduce();
        addSam += () => AddSam();
    }

    void SamStartReduce()
    {
        StartCoroutine(SamReduce(SamReducenum));
        UpdateSam();
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

    void UpdateSam()
    {
        SamSlider.fillAmount = (float)(MaxSam / currentSam);
    }

    void AddSam()
    {
        currentSam += addsam;
        UpdateSam();
    }
}
