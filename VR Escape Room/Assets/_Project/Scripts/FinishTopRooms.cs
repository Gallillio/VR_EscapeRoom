using UnityEngine;

public class FinishTopRooms : MonoBehaviour
{
    private WinEventRoom_1 winEventRoom_1Script;
    private founditems founditemsScript;

    private void OnTriggerEnter(Collider other)
    {

    }

    [SerializeField] private GameObject disappearingFence;

    void Start()
    {
        winEventRoom_1Script = GameObject.Find("Room1WinEvent").GetComponent<WinEventRoom_1>();
        founditemsScript = GameObject.Find("GarderobHide_Drawer_0").GetComponent<founditems>();
    }

    void Update()
    {
        //Debug.Log(winEventRoom_1Script.WinRoom_1 + " " + founditemsScript.WinRoom_2);
        //when 3 top levels are done
        if (winEventRoom_1Script.WinRoom_1 && founditemsScript.WinRoom_2)
        {
            disappearingFence.SetActive(false);
        }
    }
}
