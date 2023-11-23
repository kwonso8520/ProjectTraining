using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnLight : MonoBehaviour
{
    [SerializeField]
    private GameObject Light;
    [SerializeField]
    private Slider gaugeBar;
    [SerializeField]
    public float maxLightGauge = 100;
    [SerializeField]
    public float currentLightGauge;
    [SerializeField]
    private float useGaugeSpeed = 5;
    [SerializeField]
    private float recoverGaugeSpeed = 3;


    private bool ableTurnOn = true;
    private bool onLight;

    private void Awake()
    {
        currentLightGauge = maxLightGauge;
    }
    void Update()
    {
        CheckAbleTurnOn();
        SwitchPower();
    }
    private void SwitchPower()
    {
        if (Input.GetMouseButton(0) && ableTurnOn)
        {
            StopCoroutine("Delay");
            currentLightGauge -= useGaugeSpeed * Time.deltaTime;
            onLight = true;
        }
        else if ((Input.GetMouseButtonUp(0) || !ableTurnOn) && onLight)
        {
            StartCoroutine("Delay");
            onLight = false;
        }

        Light.SetActive(onLight);
        gaugeBar.value = currentLightGauge / maxLightGauge;
    }
    private void CheckAbleTurnOn()
    {
        if (gaugeBar.value <= 0)
        {
            ableTurnOn = false;
        }
        else
        {
            ableTurnOn = true;
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine("RecoverGauge");
    }

    private IEnumerator RecoverGauge()
    {
        while (true)
        {
            currentLightGauge += recoverGaugeSpeed * Time.deltaTime;
            if (onLight)
            {
                yield break;
            }
            yield return null;
        }
    }
}