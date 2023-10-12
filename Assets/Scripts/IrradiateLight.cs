using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrradiateLight : MonoBehaviour
{
    [SerializeField]
    private GameObject flashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPower();
    }
    private void SwitchPower()
    {
        if(Input.GetMouseButton(0))
        {
            flashLight.SetActive(true);
        }
        else
        {
            flashLight.SetActive(false);
        }
    }
}
