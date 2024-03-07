using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaatterySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject batteery;
    void Start()
    {
        int percent = (int)Random.Range(0f, 6f);
        if(percent == 0)
        {
            Instantiate(batteery);
        }
    }
}
