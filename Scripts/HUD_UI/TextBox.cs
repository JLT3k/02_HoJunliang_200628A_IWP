using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        text.text = "";
    }
    public void DisplayMessage(string msg)
    {
        text.text += "\n" + msg;
        //Debug.Log(msg);
    }
}
