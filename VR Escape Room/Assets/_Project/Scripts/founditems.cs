using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class founditems : MonoBehaviour
{
    // UI text component to display count of "PickUp" objects collected.
    public TMP_Text countText;
    private Text countTextComponent;
    private int count;

    // UI object to display winning text.
    public GameObject done;

    void Start()
    {
        // Check if countText is assigned
        if (countText != null)
        {
            // Get the Text component from the countText GameObject
            countTextComponent = countText.GetComponent<Text>();

            // Check if the countTextComponent is assigned properly
            if (countTextComponent == null)
            {
                Debug.LogError("Text component not found on countText GameObject.");
            }
        }
        else
        {
            Debug.LogError("countText GameObject is not assigned in the Inspector.");
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

            // Update the count display.
            SetCountText();
        }
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Check if countTextComponent is not null before updating the text
        if (countTextComponent != null)
        {
            // Update the count text with the current count.
            countTextComponent.text = "Count: " + count.ToString();
        }

        // Check if the count has reached or exceeded the win condition.
        if (count >= 6)
        {
            // Display the win text if done is not null
            if (done != null)
            {
                done.SetActive(true);
            }

            // Deactivate the countText GameObject if countText is not null
            if (countText != null)
            {
                countText.SetActive(false);
            }
        }
    }
}
