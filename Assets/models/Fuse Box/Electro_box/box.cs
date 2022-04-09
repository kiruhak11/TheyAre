using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public static bool click;
    void OnMouseDown()
    {
        if(!click){
             click = true;
        }
    }
    void Start()
    {
        click = false;
    }
}
