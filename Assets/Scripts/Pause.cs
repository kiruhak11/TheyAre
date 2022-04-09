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
    private GameObject player;

    PlayerCam playerCam;

    void Start(){
        isPaused = false;
        playerCam = player.GetComponent<PlayerCam>();
    }

    public void unpause(){
        isPaused = !isPaused;
    }

    void Update(){
        if(Input.GetKeyDown(pauseButton)){
            isPaused = !isPaused;
        }

        if(isPaused){
            pausePanel.SetActive(true);
            player.GetComponent<PlayerCam>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
        } else {
            pausePanel.SetActive(false);
            player.GetComponent<PlayerCam>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
