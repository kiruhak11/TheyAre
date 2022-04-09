using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{   
    public GameObject player;
    public GameObject FirstCam;
    public Animator anim;
    public AudioSource audio, startAu;
    public GameObject main_text;
    public GameObject start_text;
    public GameObject next_page;
    [SerializeField]
    private KeyCode pauseButton;
    public GameObject last_page;
    public GameObject UI;
    public GameObject full_UI;
    float Timer_next = 10f;
    float timers = 4f;
    float timeer = 3f;
    bool one;
    bool next;
    bool exit;
    bool onetime = true;
    public static bool siren = false;
    // Start is called before the first frame update
    void Start()
    {   
        player.SetActive(false);
        FirstCam.SetActive(true);
        main_text.SetActive(false);
        start_text.SetActive(true);
        next_page.SetActive(false);
        last_page.SetActive(false);
        one = false;
        next = false;
        exit = false;
        UI.SetActive(true);
        full_UI.SetActive(false);
        anim = anim.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Before();
        if (Timer_next > 0){
            Timer_next -= 1f * 0.02f;
        }
        if(Timer_next <= 0 && !one){
            one = true;
            Timer_next = 5f;
            main_text.SetActive(true);
            start_text.SetActive(false);
        }
        if(Timer_next <= 0 && one){
            next_page.SetActive(true);
            Nexter();
        }
        if(Input.GetKey(pauseButton)){
            next = true;
            siren = true;
        }
        if(siren && onetime){
            audio.Play();
            startAu.Play();
            onetime = false;
        } 
    }
    void Nexter(){
         
        if(next){
            next_page.SetActive(false);
            main_text.SetActive(false);
            last_page.SetActive(true);
            if(timers > 0){
                timers -= 1f * 0.02f;
            }
            if(timers <= 0){
                last_page.SetActive(false);
                UI.SetActive(false);
                exit = true;
                anim.SetBool("yes", true);
            }
        }
    }
    void Before(){
        if(exit){
            if(timeer > 0){
                timeer -= 1f * 0.02f;
            }
            if(timeer <= 0){
                FirstCam.SetActive(false);
                player.SetActive(true);
                
                full_UI.SetActive(true);
            }
        }
    }
}
