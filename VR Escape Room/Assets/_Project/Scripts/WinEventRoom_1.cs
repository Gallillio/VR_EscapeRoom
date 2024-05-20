using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEventRoom_1 : MonoBehaviour
{
    private PushDoor pushDoorScript;

    private void Start()
    {
        pushDoorScript = GameObject.Find("room1door").GetComponent<PushDoor>();
    }

    public void WinEventFunc()
    {
        pushDoorScript.PushDoorFunc();
    }
}
