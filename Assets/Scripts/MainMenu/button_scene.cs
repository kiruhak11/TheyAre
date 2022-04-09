using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_scene : MonoBehaviour
{
    public int sceneIndex;
    private void OnMouseDown() {        
        SceneManager.LoadScene(sceneIndex);
    }
}
