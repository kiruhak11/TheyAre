using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{   
    public GameObject light;
    public GameObject Imageon;
    public GameObject Imageoff;
    public bool onLight;
    // Start is called before the first frame update
    void Start(){
        onLight = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && flashlight.flashlight_take){
            onLight = !onLight;
        }
        if(onLight == false){
            light.SetActive(false);
            Imageoff.SetActive(true);
            Imageon.SetActive(false);
        } else {
            light.SetActive(true);
            Imageoff.SetActive(false);
            Imageon.SetActive(true);
        }
    }
}
