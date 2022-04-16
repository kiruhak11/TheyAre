using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatingPlayer : MonoBehaviour
{
    [HideInInspector]
    public static bool isPaused;
    [SerializeField]
    private KeyCode pauseButton;
    [SerializeField]
    private GameObject UpdatePanel;
    [SerializeField]
    private GameObject player;

    public Text TextAdd;

    public Text TextTake;
    public Text TextSpeed;

    PlayerCam playerCam;

    void Start(){
        isPaused = false;
        playerCam = player.GetComponent<PlayerCam>();
    }

    public void unpause(){
        isPaused = !isPaused;
    }
    public void Updating(){
        TextAdd.text = PlayerMovement.staminaAdd + " в сек.";
        TextTake.text = PlayerMovement.staminaTake + " в сек.";
        TextSpeed.text = PlayerMovement.sprintSpeed + " ";
    }
    public void TapToUpdateAdd(){
        PlayerMovement.staminaAdd += 1;
    }
    public void TapToUpdateSpeedAdd(){
        PlayerMovement.sprintSpeed += 1;
    }
    public void TapToUpdateSpeedMiss(){
        PlayerMovement.sprintSpeed -= 1;
    }
    public void TapToUpdateTake(){
        if (PlayerMovement.staminaTake != 1){
            PlayerMovement.staminaTake -= 1;
        }
    }

    void Update(){
        Updating();
        if(Input.GetKeyDown(pauseButton)){
            isPaused = !isPaused;
        }

        if(isPaused){
            UpdatePanel.SetActive(true);
            player.GetComponent<PlayerCam>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
        } else {
            UpdatePanel.SetActive(false);
            player.GetComponent<PlayerCam>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
