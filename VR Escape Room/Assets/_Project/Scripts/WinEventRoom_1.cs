using UnityEngine;

public class WinEventRoom_1 : MonoBehaviour
{
    private PushDoor pushDoorScript;
    [HideInInspector] public bool WinRoom_1;

    private void Start()
    {
        pushDoorScript = GameObject.Find("room1door").GetComponent<PushDoor>();
    }

    public void WinEventFunc()
    {
        pushDoorScript.PushDoorFunc();
    }
}
