using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private int countTutorials;
    [SerializeField] private string[] text;
    [SerializeField] private Text uiText;
    [SerializeField] private GameObject panel;
    public void changeText()
    {
       
        uiText.text =  text[countTutorials];
        if(text.Length >= countTutorials)
        {
            panel.SetActive(false);
        }
    }

}
