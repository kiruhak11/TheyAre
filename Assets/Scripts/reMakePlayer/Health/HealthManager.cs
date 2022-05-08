using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float HealthPlayer = 100;
    public GameObject player;
    public GameObject PanelDeath;
    public Text HealthText;
    void Update()
    {
        HealthText.text = Mathf.Round(HealthPlayer) + " ";
        fixHealth();
        death();
    }
    public void fixHealth(){
        if(HealthPlayer < 0){
            HealthPlayer = 0f;
        }
    }
    void death(){
        if(HealthPlayer <= 0){
            PanelDeath.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
        }
    }
    public void LastSave(){
        PanelDeath.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
