using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takeDamage : MonoBehaviour
{
    
    public Image img; // ваша картинка
    public float t; // ваше значение прозрачности.

    void Start() {
        FadeIn();
    }

    public void FadeIn (){
        float t = 0f; // сначала она 100% не прозрачна, поэтому t = 1

        while (t < 0.4f){
            t += Time.deltaTime* 0.11f;
            img.color = new Color (0.88f, 0f, 0f, t); // и обновляем прозрачность картинки с помощью "a"
        }
        if (t >= 0.4f){
            while (t != 0f){
                t -= Time.deltaTime* 0.1f;
                img.color = new Color (0.88f, 0f, 0f, t); // и обновляем прозрачность картинки с помощью "a"
            }
        }
    }
    
}
