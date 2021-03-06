using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatingPlayer : MonoBehaviour
{
    [HideInInspector]
    public static bool UpdatePause;
    [SerializeField]
    private KeyCode pauseButton;
    [SerializeField]
    private KeyCode pauseButton2;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject use;
    [SerializeField]
    private GameObject tipObj;
    PlayerCam playerCam;

    private float maxStaminaAdd = 5f; 
    private float maxStaminaTake = 5f;
    private float nowStaminaAdd = 0f; 
    private float nowStaminaTake = 0f;
    private float nowUpdatePriceStamina = 1f;
    private float nowUpdatePriceStaminaTake = 1f;

    public float pointUpdate;

    [Header("Panels")]
    public GameObject staminaPanel;
    public GameObject ExoScilet;
    public GameObject hud;
    public GameObject UpdatePanel;
    public GameObject GunsPanel;

    [Header("Texts")]
    public Text tip;
    public Text TextAddStamina;
    public Text countPoint;
    public Text TextTakeStamina;
    public Text nowUpdatePriceStaminaText;
    public Text nowUpdatePriceStaminaTakeText;
    public GameObject PlayerObj;
    private HealthManager healthManager;


    void Start(){
        UpdatePause = false;
        playerCam = player.GetComponent<PlayerCam>();
        healthManager = PlayerObj.GetComponent<HealthManager>();
    }

    public void unpause(){
        UpdatePause = !UpdatePause;
    }
    public void Updating(){
        TextAddStamina.text = nowStaminaAdd + " / " + maxStaminaAdd;
        TextTakeStamina.text = nowStaminaTake + " / " + maxStaminaTake;
    }
    public void TapToUpdateAdd(){
        if(pointUpdate >= nowUpdatePriceStamina && nowStaminaAdd != maxStaminaAdd){
            pointUpdate -= nowUpdatePriceStamina;
            nowStaminaAdd += 1f;
            nowUpdatePriceStamina = nowUpdatePriceStamina * 2f;
            staminaChecker();
        }
        
    }
    public void TapToUpdateTake(){
        if(pointUpdate >= nowUpdatePriceStaminaTake && nowStaminaTake != maxStaminaTake){
            pointUpdate -= nowUpdatePriceStaminaTake;
            nowStaminaTake += 1f;
            nowUpdatePriceStaminaTake = nowUpdatePriceStaminaTake * 4f;
            staminaChecker();
        }
        
    }
    public void ButtonStaminaUpdate(){
        staminaPanel.SetActive(true);
        ExoScilet.SetActive(false);
        GunsPanel.SetActive(false);
    }
    public void ButtonExoSciletUpdate(){
        ExoScilet.SetActive(true);
        staminaPanel.SetActive(false);
        GunsPanel.SetActive(false);
    }
    public void ButtonGunsUpdate(){
        GunsPanel.SetActive(true);
        ExoScilet.SetActive(false);
        staminaPanel.SetActive(false);
    }

    void Update(){

        //voids
        checkUse();
        Updating();

        //TextSetToUpdatingPlayer
        countPoint.text = "?????????? ?????????????????? " + pointUpdate;
        nowUpdatePriceStaminaText.text = "???? " + nowUpdatePriceStamina;
        nowUpdatePriceStaminaTakeText.text = "???? " + nowUpdatePriceStaminaTake;


        if(Input.GetKeyDown(pauseButton) && !Pause.isPaused){
            UpdatePause = !UpdatePause;
        }
        if(UpdatePause && Input.GetKeyDown(pauseButton2) && !Pause.isPaused){
            UpdatePause = !UpdatePause;
        }
        if(!Pause.isPaused && healthManager.HealthPlayer != 0){
            if(UpdatePause && !Pause.isPaused){
                UpdatePanel.SetActive(true);
                hud.SetActive(false);
                player.GetComponent<PlayerCam>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0;
            } else {
                UpdatePanel.SetActive(false);
                hud.SetActive(true);
                player.GetComponent<PlayerCam>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
        if(UpdatePause){
            Pause.isPaused = false;
        }
    }

    //========================

    private void staminaChecker(){
        if(nowStaminaAdd != 0){
            PlayerMovement.staminaAdd = PlayerMovement.staminaAdd + (nowStaminaAdd / 2f);
        }
        if(nowStaminaTake != 0){
            PlayerMovement.staminaTake = PlayerMovement.staminaTake - nowStaminaTake;
            if(PlayerMovement.staminaTake <= 0){
                PlayerMovement.staminaTake = 1f;
            }
        }
    }
    public void checkUse(){
        if(use.activeInHierarchy){
            tipObj.SetActive(true);
            tip.text = "E";
        } else {
            tipObj.SetActive(false);
        }
    }
}
