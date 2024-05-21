using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCounterRoom_2 : MonoBehaviour
{
    public TMP_Text countText;
    private int count;

    // UI object to display winning text.
    public GameObject done;

    void Start()
    {
        Debug.Log(countText.text);
    }

    void Update()
    {

    }
}
