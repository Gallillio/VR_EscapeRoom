using UnityEngine;

public class WinEventRoom_1 : MonoBehaviour
{
    private PushDoor pushDoorScript;
    public bool WinRoom_1 = false;

    private void Start()
    {
        pushDoorScript = GameObject.Find("room1door").GetComponent<PushDoor>();
    }

    public void WinEventFunc()
    {
        pushDoorScript.PushDoorFunc();
        WinRoom_1 = true;
    }
}
