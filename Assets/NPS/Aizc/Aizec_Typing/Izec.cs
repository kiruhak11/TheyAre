using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Izec : MonoBehaviour
{
    public static bool TRIGGER = false;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            TRIGGER = true;
        }
    }
}
