using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typing_text : MonoBehaviour
{
    public Text TextUse;
    private string text;

    private void Start()
    {
        text = TextUse.text;
        TextUse.text = "";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        foreach (char abc in text)
        {
            TextUse.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
