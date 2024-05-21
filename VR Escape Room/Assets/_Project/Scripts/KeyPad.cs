using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private TMP_Text Code;

    private string Answer = "2666668";
    private Color defaultColor = Color.white;

    void Start()
    {
        defaultColor = Code.color; // Store the default color to revert back to it if needed
    }

    public void Number(int number)
    {
        // Clear the text and reset color if it says "INCORRECT" or "Correct"
        if (Code.text == "INCORRECT" || Code.text == "Correct")
        {
            Code.text = "";
            Code.color = defaultColor;
        }
        Code.text += number.ToString();
    }

    public void Enter()
    {
        if (Code.text == Answer)
        {
            Code.text = "Correct";
            Code.color = Color.green;
        }
        else
        {
            Code.text = "INCORRECT";
            Code.color = Color.red;
        }
    }
}
