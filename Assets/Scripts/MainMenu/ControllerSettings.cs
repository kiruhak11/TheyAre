using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSettings : MonoBehaviour
{
    public Text countSens;
    public Slider sliderSens;
    private void Start() {
        sliderSens.value = PlayerCam.sens;
    }
    void Update()
    {
        countSens.text = Mathf.Round(PlayerCam.sens) + ""; 
        PlayerCam.sens = sliderSens.value; 
    }
}
