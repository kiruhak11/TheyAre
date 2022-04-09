using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Dropdown dropdown;

    // Start is called before the first frame update
    void Start() {
        dropdown.ClearOptions();
        dropdown.AddOptions(QualitySettings.names.ToList());
        if(PlayerPrefs.HasKey("Quality")){
            dropdown.value = PlayerPrefs.GetInt("Quality");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        } else dropdown.value = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void SetGraph() {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("Quality", dropdown.value);
    }
}