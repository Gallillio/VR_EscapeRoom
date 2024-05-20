using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door; // Assign the door transform in the inspector
    public Vector3 openRotation = new Vector3(0, 90, 0); // Rotation for the open door
    public float openSpeed = 2f; // Speed at which the door opens/closes
    public float distanceThreshold = 0.01f; // 1 cm threshold for closing
    public string password = "1234"; // Set your password here

    private Vector3 closedRotation; // Initial rotation of the door
    private bool isOpening = false;
    private bool isClosing = false;
    private Transform playerTransform;
    private bool isLocked = false;

    void Start()
    {
        closedRotation = door.localEulerAngles;
    }

    void Update()
    {
        if (isOpening)
        {
            door.localRotation = Quaternion.Slerp(door.localRotation, Quaternion.Euler(openRotation), Time.deltaTime * openSpeed);
            if (Quaternion.Angle(door.localRotation, Quaternion.Euler(openRotation)) < 1f)
            {
                isOpening = false;
            }
        }

        if (isClosing)
        {
            door.localRotation = Quaternion.Slerp(door.localRotation, Quaternion.Euler(closedRotation), Time.deltaTime * openSpeed);
            if (Quaternion.Angle(door.localRotation, Quaternion.Euler(closedRotation)) < 1f)
            {
                isClosing = false;
            }
        }

        if (playerTransform != null && !isLocked)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance > distanceThreshold)
            {
                isClosing = true;
                isOpening = false;
                isLocked = true; // Lock the door and require password to reopen
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            isOpening = true;
            isClosing = false;
        }
    }

    public void TryOpenDoor(string inputPassword)
    {
        if (inputPassword == password)
        {
            isOpening = true;
            isLocked = false;
        }
    }
}
