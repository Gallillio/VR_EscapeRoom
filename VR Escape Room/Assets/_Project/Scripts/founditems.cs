using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class founditems : MonoBehaviour
{
    // UI text components to display count of "PickUp" objects collected.
    public GameObject countTextUI;
    public GameObject countTextTMP;
    private Text countTextComponentUI;
    private TextMeshProUGUI countTextComponentTMP;
    private int count;

    // UI object to display winning text.
    public GameObject done;

    void Start()
    {
        // Check if countTextUI is assigned
        if (countTextUI != null)
        {
            // Get the Text component from the countTextUI GameObject
            countTextComponentUI = countTextUI.GetComponent<Text>();
            if (countTextComponentUI == null)
            {
                Debug.LogError("Text component not found on countTextUI GameObject.");
            }
        }

        // Check if countTextTMP is assigned
        if (countTextTMP != null)
        {
            // Get the TextMeshProUGUI component from the countTextTMP GameObject
            countTextComponentTMP = countTextTMP.GetComponent<TextMeshProUGUI>();
            if (countTextComponentTMP == null)
            {
                Debug.LogError("TextMeshProUGUI component not found on countTextTMP GameObject.");
            }
        }

        // Check if done is assigned
        if (done == null)
        {
            Debug.LogError("done GameObject is not assigned in the Inspector.");
        }

        count = 0;
        SetCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "collectables" tag.
        if (other.gameObject.CompareTag("collectables"))
        {
            // Deactivate the collected object (making it disappear).
            other.gameObject.SetActive(false);

            // Increment the count of "collectable" objects collected.
            count = count + 1;
            Debug.Log("mawgod.");
            // Update the count display.
            SetCountText();
        }
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Update the count text with the current count if using UnityEngine.UI.Text
        if (countTextComponentUI != null)
        {
            countTextComponentUI.text = "Count: " + count.ToString();
        }

        // Update the count text with the current count if using TextMeshProUGUI
        if (countTextComponentTMP != null)
        {
            countTextComponentTMP.text = "Count: " + count.ToString();
        }

        // Check if the count has reached or exceeded the win condition.
        if (count >= 6)
        {
            // Display the win text if done is not null
            if (done != null)
            {
                done.SetActive(true);
            }

            // Deactivate the countText GameObject if countTextUI or countTextTMP is not null
            if (countTextUI != null)
            {
                countTextUI.SetActive(false);
            }

            if (countTextTMP != null)
            {
                countTextTMP.SetActive(false);
            }
        }
    }
}
