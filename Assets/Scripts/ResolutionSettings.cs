using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResolutionSettings : MonoBehaviour
{

    public Dropdown dropdown; 
    Resolution [] res;
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {  
       
        //fullscreen
        
        if(PlayerPrefs.HasKey("scrmod")){
            if(PlayerPrefs.GetInt("scrmod") == 0){
                Screen.fullScreen = false;
                toggle.isOn = !Screen.fullScreen;
            } else {
                Screen.fullScreen = true;
                toggle.isOn = !Screen.fullScreen;
            }
        } else {
            Screen.fullScreen = true;
            toggle.isOn = !Screen.fullScreen;
        } 
        //resolstart
        Resolution [] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string [] strRes = new string[res.Length];
        
        //setDDlist
        for (int i = 0; i < res.Length; i++){
            strRes[i] = res[i].ToString();
        }

        //ddAdded
        dropdown.ClearOptions();
        dropdown.AddOptions(strRes.ToList());
        if(PlayerPrefs.HasKey("res")){
            dropdown.value = PlayerPrefs.GetInt("res");
            Screen.SetResolution(res[PlayerPrefs.GetInt("res")].width, res[PlayerPrefs.GetInt("res")].height, Screen.fullScreen);
        } else {
            Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
            dropdown.value = res.Length - 1;
        }

    }

    // Update is called once per frame
    public void setRes(){
        Screen.SetResolution(res[dropdown.value - 1].width, res[dropdown.value - 1].height, Screen.fullScreen);
        PlayerPrefs.SetInt("res", dropdown.value);
    }

    public void ScreenMode(){
        Screen.fullScreen = !toggle.isOn;
        if(Screen.fullScreen){
            PlayerPrefs.SetInt("scrmod", 1);
        } else {
            PlayerPrefs.SetInt("scrmod", 0);
        }
    }
}
