using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public static bool click;
    public static bool isEnter = false;
    private float dist;
    public AudioSource siren;
    public GameObject player;

    private void OnMouseEnter()
    {
        if (dist <= 4)
        {
            isEnter = true;
        }
        else isEnter = false;
    }

    private void OnMouseExit()
    {
        isEnter = false;
    }

    void Start()
    {
        click = false;
    }

    private void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (isEnter && dist <= 3 && Input.GetKeyDown(KeyCode.E))
        {
            siren.Pause();
            gameObject.GetComponent<Outline>().enabled = false;
            beforStarter.offSiren = true;
        }

    }
}
