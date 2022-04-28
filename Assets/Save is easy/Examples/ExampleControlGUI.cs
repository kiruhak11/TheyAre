using SaveIsEasy;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExampleControlGUI : MonoBehaviour {

    //to avoid setting an empty name we use sceneFileName variable
    private string sceneFileName;
    private Scene selected;

    private void Start() {
        selected = SceneManager.GetSceneAt(0);
        sceneFileName = SaveIsEasyAPI.GetSceneFileNameByScene(selected);
    }
    public void SaveAll(){
        SaveIsEasyAPI.SaveAll(selected);
    }
    public void LoadAll(){
        SaveIsEasyAPI.LoadAll(selected);
    }
}
