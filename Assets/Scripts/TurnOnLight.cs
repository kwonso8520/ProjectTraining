using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    [SerializeField]
    private GameObject Light;
    void Update()
    {
        SwitchPower();
    }
    private void SwitchPower()
    {
        if (Input.GetMouseButton(0))
        {
            Light.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
        }
    }
}
