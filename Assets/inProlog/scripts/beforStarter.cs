using System;
using System.Collections;
using System.Collections.Generic;
using inProlog.scripts;
using UnityEngine;

public class beforStarter : MonoBehaviour
{
    private bool takeFlashLight;
    public static bool offSiren;

    [Header("Objects")]
    public GameObject flashLightGo;
    public GameObject offSirenAndOnLight;


    void Start()
    {
        takeFlashLight = false;
        offSiren = false;
        offSirenAndOnLight.GetComponent<Outline>().enabled = false;
    }

    private void Update()
    {
        if (starter.ending && !takeFlashLight)
        {
            flashLightGo.GetComponent<Outline>().enabled = true;
            offSirenAndOnLight.GetComponent<Outline>().enabled = false;
            takeFlashLight = true;
        }

        if (takeFlashLight)
        {
            if(!offSiren)
                offSirenAndOnLight.GetComponent<Outline>().enabled = true;
            offSiren = true;
        }
    }
}
