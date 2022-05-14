using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class light_mainMenu : MonoBehaviour
{
    public GameObject thisLight;
    public float timer1;
    public float timer2 = 0.1f;
    public float timer3 = 0.1f;
    public float timer4 = 0.1f;

    void Start() {
        timer1 = Random.Range(10.0f, 60.0f);
    }
    void Update() {
        if (timer1 > 0){
            timer1 = timer1 - 1f * 0.02f;
        }
        if (timer1 <= 0){
            thisLight.SetActive(false);
            timer2 = timer2 - 1f * 0.02f;
        }
        if (timer2 <= 0){
            thisLight.SetActive(true);
            timer3 = timer3 - 1f * 0.02f;
        }
        if (timer3 <= 0){
            thisLight.SetActive(false);
            timer4 = timer4 - 1f * 0.02f;
        }
        if (timer4 <= 0){
            thisLight.SetActive(true);
            timer2 = 0.1f;
            timer4 = 0.1f;
            timer3 = 0.1f;
            timer1 = Random.Range(10.0f, 30.0f);
        }
    }
}
