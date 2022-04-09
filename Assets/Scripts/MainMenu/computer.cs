using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer : MonoBehaviour
{
    public GameObject camera_one;
    public GameObject camera_two;
    bool cams;
    private void OnMouseDown() {
        cams = !cams;
    }
    void Update()
    {
        if(cams){
            camera_one.SetActive(false);
            camera_two.SetActive(true);
        } else {
            camera_one.SetActive(true);
            camera_two.SetActive(false);
        }
    }
}
