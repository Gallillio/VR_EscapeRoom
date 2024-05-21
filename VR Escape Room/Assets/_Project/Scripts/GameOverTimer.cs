using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverTimer : MonoBehaviour
{
    private TMP_Text timerText;
    [SerializeField] private float remainingTime;

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 0)
        {
            GameOverEvent();
        }
    }

    public void GameOverEvent()
    {

    }
}
