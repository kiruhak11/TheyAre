using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public GameObject lighter;
    public bool lightOn;
    public AudioSource lig;
    public GameObject interaction_image;
    public GameObject player;
    public bool isEnter = false;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        lightOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && dist < 3f && isEnter){
            lightOn = !lightOn;
            lig.Play();
        }

        if(isEnter && dist < 3f){
            interaction_image.SetActive(true); 
        } 


        dist = Vector3.Distance(player.transform.position, transform.position);
        if(lightOn){
            lighter.SetActive(true);
        } else lighter.SetActive(false);
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
