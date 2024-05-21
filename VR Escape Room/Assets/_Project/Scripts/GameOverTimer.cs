using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverTimer : MonoBehaviour
{
    private TMP_Text timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] private Image screenOverlay;
    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
        screenOverlay.gameObject.SetActive(false); // disable e7tyaty
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
        screenOverlay.gameObject.SetActive(true); // Enable the overlay
        screenOverlay.color = new Color(1, 0, 0, 0.2f);
        remainingTime = 0;
    }
}
