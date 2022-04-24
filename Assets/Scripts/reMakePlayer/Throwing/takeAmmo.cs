using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeAmmo : MonoBehaviour
{
    public Animator anim;
    public float dist;
    public GameObject player;
    public GameObject interaction_image;
    public bool isEnter;

    void OnMouseEnter() {
        if(gameObject.tag == "Door") isEnter = true;            
        
    }
    void OnMouseExit() {
        if(gameObject.tag == "Door"){
            isEnter = false;
            interaction_image.SetActive(false);    
        }
    }
    void click(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(dist < 3f && isEnter){
                anim.SetTrigger("open");
                if(gameObject.tag == "Door"){
                    Throwing.totalThrows += 10;
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.E)){
            
        }
    }
    void Update()
    {
        if(isEnter && dist < 4f){
            interaction_image.SetActive(true); 
        } 

        dist = Vector3.Distance(player.transform.position, transform.position);
        click();
    }
}
