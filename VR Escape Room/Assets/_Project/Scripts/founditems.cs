using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class founditems : MonoBehaviour
{
    // UI text component to display count of "PickUp" objects collected.
    public TMP_Text countText;
    private int count;

    // UI object to display winning text.
    public GameObject done;

    public bool WinRoom_2 = false;

    void Start()
    {
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

            // Update the count display.
            SetCountText();
        }
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Check if countTextComponent is not null before updating the text
        if (countText != null)
        {
            // Update the count text with the current count.
            countText.text = "Count: " + count.ToString();
        }

        // Check if the count has reached or exceeded the win condition.
        if (count >= 3)
        {
            // Display the win text if done is not null
            if (done != null)
            {
                done.SetActive(true);
                WinRoom_2 = true;
            }

            // Deactivate the countText GameObject if countText is not null
            if (countText != null)
            {
                countText.gameObject.SetActive(false);
            }
        }
    }
}
