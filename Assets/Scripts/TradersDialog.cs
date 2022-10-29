using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradersDialog : MonoBehaviour
{
    [SerializeField] Text DialogText;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] string[] Dialog;
    public int count =0;

    private void Start()
    {
        DialogText.text = Dialog[count];
    }
    public void NextMessage()
    {
        DialogText.text = Dialog[count];
        count++;
        

    }
    private void Update()
    {
        if(count >= Dialog.Length)
        {
            count = 0;
        }
    }
   
}
