using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public InputField inputfield;
   
    public void Input(Text text) => text.text = inputfield.text;
    private void Update()
    {
        if (inputfield.isFocused)
        {
            inputfield.placeholder.GetComponent<Text>().text = "";
        }
    }
}
