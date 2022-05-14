using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkColision : MonoBehaviour
{
    public GameObject lig;
    public AudioSource projector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lig.SetActive(true);
            projector.Play();
        }
    }
}
