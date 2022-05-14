using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStart : MonoBehaviour
{
    public float timerToStartLight = 3f;
    public float player;
    public GameObject lig;

    private void Start()
    {
        lig.SetActive(false);
    }

    private void Update()
    {
        if(timerToStartLight != 0)
            timerToStartLight -= 1 * Time.deltaTime;
        if (timerToStartLight <= 0)
        {
            lig.SetActive(true);
        }
    }
}

