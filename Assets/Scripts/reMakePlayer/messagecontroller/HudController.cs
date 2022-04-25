using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Animator anim;
    public Text textMessage;

    public void message(string mission){
        textMessage.text = mission;
        anim.SetTrigger("go");
        anim.SetTrigger("back");
    } 
}
