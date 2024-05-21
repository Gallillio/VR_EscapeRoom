using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        public TextMeshProUGUI m_StepButtonTextField;

        [SerializeField]
        List<Step> m_StepList = new List<Step>();

        int m_CurrentStepIndex = 0;

        public void Next()
        {
            if (m_StepList == null || m_StepList.Count == 0)
            {
                Debug.LogError("Step list is null or empty!");
                return;
            }

            if (m_StepList[m_CurrentStepIndex] == null)
            {
                Debug.LogError($"Step at index {m_CurrentStepIndex} is null!");
                return;
            }

            if (m_StepList[m_CurrentStepIndex].stepObject == null)
            {
                Debug.LogError($"Step object at index {m_CurrentStepIndex} is null!");
                return;
            }

            if (m_StepButtonTextField == null)
            {
                Debug.LogError("Step button text field is not assigned!");
                return;
            }

            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex = (m_CurrentStepIndex + 1) % m_StepList.Count;

            if (m_StepList[m_CurrentStepIndex].stepObject == null)
            {
                Debug.LogError($"Step object at new index {m_CurrentStepIndex} is null!");
                return;
            }

            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }
    }
}
