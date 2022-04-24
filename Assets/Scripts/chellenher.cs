using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chellenher : MonoBehaviour
{   
    public Text text_mission;
    public Text text_tip;
    
    public GameObject flashlights, shetok, IzecNPS;
    public GameObject text_tip_GO;
    public GameObject text_mission_GO;
    public GameObject UI;
    [SerializeField]
    private KeyCode missionButton;
    float panel_timer = 3f;
    public GameObject player;
    public AudioSource audio, goToIzec, Prigoditca;
    bool first_tip_show = true;
    bool first_tip_show_helper = true;
    bool first_mission_show = true;
    int missions = 0;
    float dist;
    float a = 3f;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        text_tip_GO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.activeInHierarchy){
            Take_flashlight();
            Panel_m();
            FixSus();
            MoveToIzec();
            HideTips();
        }
        if(!first_tip_show_helper){
            text_tip.text = "Для открытия заданий, нажмите 'TAB'";
            text_tip_GO.SetActive(true);
            first_tip_show = false;
            first_tip_show_helper = true;
                   
        }
        
    }
    void Take_flashlight(){
        if(missions == 0) {
            dist = Vector3.Distance(player.transform.position, flashlights.transform.position);
            SetMissions(mission: "Возьмите фонарик в шкафу \n Дистанция:" +  Mathf.Round(dist));
            flashlights.GetComponent<Outline>().enabled = true;
            if(first_mission_show){
                UI.SetActive(true);
                first_mission_show = false;
            }
            if(flashlight.flashlight_take){
                missions = 1;
                first_mission_show = true;
                SetTips(tips:"Для включения фонарика нажмите 'F'");
                Prigoditca.Play();
                    text_tip_GO.SetActive(true);
                first_tip_show = false;
                first_tip_show_helper = true;
            }
        }
    }
    void Panel_m(){
        if(UI.activeInHierarchy){
            if(panel_timer > 0){
                panel_timer -= 1f * 0.02f;
            } else if(panel_timer <= 0){
                if(first_tip_show){
                    first_tip_show_helper= false;
                }
                UI.SetActive(false);
                panel_timer = 3f;
            }

        } else if(Input.GetKey(missionButton)){
            UI.SetActive(true);
        }
        
    }
    void FixSus(){
        if (missions == 1){
            dist = Vector3.Distance(player.transform.position, shetok.transform.position);
            SetMissions(mission: "Отключите сигнализацию в электро-блоке \n Дистанция:" +  Mathf.Round(dist));
            shetok.GetComponent<Outline>().enabled = true;
            if(first_mission_show){
                UI.SetActive(true);
                first_mission_show = false;
            }
            if(box.click){
                shetok.GetComponent<Outline>().enabled = false;
                shetok.GetComponent<Door>().enabled = false;
                SetTips(tips: "Томас: Надо пойти и поговорить с Айзеком!");
                goToIzec.Play();
                text_tip_GO.SetActive(true);
                first_tip_show = false;
                first_tip_show_helper = true;
                missions = 2;
                first_mission_show = true;
            }
        }
    }
    void MoveToIzec(){
        if(missions == 2){
            SetMissions(mission: "Пройдите в комнату к айзеку");
            audio.Stop();
            IzecNPS.GetComponent<Outline>().enabled = true;
            if(first_mission_show){
                UI.SetActive(true);
                first_mission_show = false;
            }
            if(Izec.TRIGGER){
                IzecNPS.GetComponent<Outline>().enabled = false;
            }
        }
    }

    public void SetMissions(string mission){
        text_mission.text = mission;
    }
    public void SetTips(string tips){
        text_tip.text = tips;
    }
    void HideTips(){
        if(text_tip_GO.activeInHierarchy){
            if(a > 0) {
                a -= 0.02f;
            } else if(a <=0) {
                a = 3f;
                text_tip_GO.SetActive(false);
            }
        }
    }
}



