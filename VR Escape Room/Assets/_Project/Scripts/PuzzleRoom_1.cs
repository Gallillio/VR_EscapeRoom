using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom_1 : MonoBehaviour
{
    [SerializeField] private bool correctLetter = false;
    [SerializeField] private bool correctNumber = false;

    private Transform passwordTextOnDesk;

    private void Start()
    {
        passwordTextOnDesk = GameObject.Find("PasswordText").GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        passwordTextOnDesk.gameObject.SetActive(false);

        if (other.CompareTag("LettersAndNumbers") && other.name == "letter_L")
        {
            correctLetter = true;
        }
        if (other.CompareTag("LettersAndNumbers") && other.name == "figure_2")
        {
            correctNumber = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        passwordTextOnDesk.gameObject.SetActive(true);

        if (other.CompareTag("LettersAndNumbers") && other.name == "letter_L")
        {
            correctLetter = false;
        }
        if (other.CompareTag("LettersAndNumbers") && other.name == "figure_2")
        {
            correctNumber = false;
        }
    }
}
