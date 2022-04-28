using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reMakeChellenger : MonoBehaviour
{
    public Toggle fiveKills;

    public static int countKills;
    public GameObject TargetObj;
    private HudController _actionTarget;
    public GameObject UIManager;
    private UpdatingPlayer updatingPlayer;
    bool fiveKillBool;

    private void Start() {
        _actionTarget = TargetObj.GetComponent<HudController>();
        updatingPlayer = UIManager.GetComponent<UpdatingPlayer>();
    }
    private void Update() {
        if(!fiveKillBool && countKills >= 5){
            fiveKillsFun();
            fiveKillBool = true;
        }
    }
    void fiveKillsFun(){
        fiveKills.isOn = true;
        _actionTarget.message(mission: "Миссия выполнена! \n вы получили 12 очков улучшений ");
        updatingPlayer.pointUpdate += 12;
    }
}
