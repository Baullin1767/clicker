using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleLocalization : MonoBehaviour
{
    [SerializeField] string ru;
    [SerializeField] string eng;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            text.text = ru;
        }
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            text.text = eng;
        }
    }
}
