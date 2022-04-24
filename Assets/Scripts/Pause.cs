using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour{
    [HideInInspector]
    public static bool isPaused;
    [SerializeField]
    private KeyCode pauseButton;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject textMissions;
    [SerializeField]
    private GameObject player;

    PlayerCam playerCam;
    public GameObject Options;
    public GameObject hud;

    void Start(){
        isPaused = false;
        playerCam = player.GetComponent<PlayerCam>();
    }

    public void unpause(){
        isPaused = !isPaused;
    }

    void Update(){
        if(Input.GetKeyDown(pauseButton) && !UpdatingPlayer.UpdatePause){
            isPaused = !isPaused;
        } else
        if(!UpdatingPlayer.UpdatePause){
            if(isPaused){
                pausePanel.SetActive(true);
                hud.SetActive(false);
                player.GetComponent<PlayerCam>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0;
            } else {
                pausePanel.SetActive(false);
                hud.SetActive(true);
                player.GetComponent<PlayerCam>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
    }

    //buttons 

    public void buttonOptionsIn(){
        Options.SetActive(true);
        textMissions.SetActive(false);
    }
    public void buttonOptionsOut(){
        Options.SetActive(false);
        textMissions.SetActive(true);
    }
}
