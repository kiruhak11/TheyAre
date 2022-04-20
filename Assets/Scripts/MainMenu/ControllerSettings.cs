using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSettings : MonoBehaviour
{
    public Text countSens;
    public Slider sliderSens;
    public InputField field;
    private void Start() {
        sliderSens.value = PlayerCam.sens;
        field.text = PlayerCam.sens + "";
    }
    void Update()
    {
        countSens.text = Mathf.Round(PlayerCam.sens) + ""; 
        PlayerCam.sens = sliderSens.value;
        if(float.Parse(field.text) > 1 && float.Parse(field.text) < 1001)
            sliderSens.value = float.Parse(field.text);
        
    }
}
