using System.Collections;
using UnityEngine;

namespace NavKeypad
{
    public class KeypadButton : MonoBehaviour
    {
        [Header("Value")]
        [SerializeField] private string value;
        [Header("Button Animation Settings")]
        [SerializeField] private float bttnspeed = 0.1f;
        [SerializeField] private float moveDist = 0.0025f;
        [SerializeField] private float buttonPressedTime = 0.1f;
        [Header("Component References")]
        [SerializeField] private Keypad keypad;
        [SerializeField] private Collider rightControllerCollider;
        [SerializeField] private Collider leftControllerCollider;

        private bool moving;

        public void PressButton()
        {
            if (!moving)
            {
                Debug.Log($"Button pressed with value: {value}");
                keypad.AddInput(value);
                StartCoroutine(MoveSmooth());
            }
        }

        private IEnumerator MoveSmooth()
        {
            moving = true;
            Vector3 startPos = transform.localPosition;
            Vector3 endPos = transform.localPosition + new Vector3(0, 0, moveDist);

            float elapsedTime = 0;
            while (elapsedTime < bttnspeed)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / bttnspeed);

                transform.localPosition = Vector3.Lerp(startPos, endPos, t);

                yield return null;
            }
            transform.localPosition = endPos;
            yield return new WaitForSeconds(buttonPressedTime);
            startPos = transform.localPosition;
            endPos = transform.localPosition - new Vector3(0, 0, moveDist);

            elapsedTime = 0;
            while (elapsedTime < bttnspeed)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / bttnspeed);

                transform.localPosition = Vector3.Lerp(startPos, endPos, t);

                yield return null;
            }
            transform.localPosition = endPos;

            moving = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            // Check if the collider belongs to the right or left controller
            if (other == rightControllerCollider || other == leftControllerCollider)
            {
                Debug.Log("Controller collider entered button trigger zone.");
                PressButton();
            }
        }
    }
}
