using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
        public int 
                SpeedMove = 0,  //скорость движения лифта
                VectorMove = 0; //направление движения
    bool up = false;
    public float w;
    public GameObject Sphere;
    void OnMouseDown() {
        up = !up;
    }
    private void Update() {
        if(w == 1){
            if(up){
                Vector3 P = Sphere.transform.position;
                P.y = P.y + SpeedMove * VectorMove * Time.deltaTime;
                Sphere.transform.position = P;
                if(Sphere.transform.position.y >= 9f){
                    up = false;
                }
            }
        }
        if(w == 2){
            if(up){
                Vector3 P = Sphere.transform.position;
                P.y = P.y + SpeedMove * VectorMove * Time.deltaTime;
                Sphere.transform.position = P;
                if(Sphere.transform.position.y <= -8f){
                    up = false;
                }
            }
        }
        if(w == 3){
            if(up){
                if(Sphere.transform.position.y > 3f){
                    VectorMove = -1;
                } else VectorMove = 1;
                Vector3 P = Sphere.transform.position;
                P.y = P.y + SpeedMove * VectorMove * Time.deltaTime;
                Sphere.transform.position = P;
                if(Sphere.transform.position.y >= 2.9f && Sphere.transform.position.y <= 3.1f){
                    up = false;
                }
            }
        }
    }
}
