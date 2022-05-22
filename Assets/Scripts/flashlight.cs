using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{   
    public GameObject interaction_image;
    public GameObject player;
    public bool isEnter = false;
    public float dist;
    public static bool flashlight_take = false;
    public GameObject TargetObj;
    private HudController _actionTarget;

    private void Start()
    {
        _actionTarget = TargetObj.GetComponent<HudController>();
    }

    void Update()
    {

        if(isEnter && dist < 3f){
            interaction_image.SetActive(true); 
        } 
        if(isEnter && dist < 3f && (Input.GetKeyDown(KeyCode.E))){
            flashlight_take = true;
            _actionTarget.message(mission: "Вы подняли фонарик");
            Destroy(gameObject); 
        }

        dist = Vector3.Distance(player.transform.position, transform.position);
    }
    void OnMouseEnter() {
        if(gameObject.tag == "Door") isEnter = true;            
        
    }
    void OnMouseExit() {
        if(gameObject.tag == "Door"){
            isEnter = false;
            interaction_image.SetActive(false);    
        }
    }
}
