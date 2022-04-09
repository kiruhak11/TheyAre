using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{
	public void ChangeScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

    public void Close(GameObject close){
        close.SetActive(false);
    }
    public void Open(GameObject open){
        open.SetActive(true);
    }
	public void Exit()
	{
		Application.Quit ();
	}

}
