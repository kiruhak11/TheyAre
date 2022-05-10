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
    void Update()
    {

        if(isEnter && dist < 3f){
            interaction_image.SetActive(true); 
        } 
        if(isEnter && dist < 3f && (Input.GetKeyDown(KeyCode.E))){
            flashlight_take = true;
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
