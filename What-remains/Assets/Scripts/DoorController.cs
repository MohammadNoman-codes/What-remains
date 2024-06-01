using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public float openRot = 0f; // Open rotation set to 0 degrees
    public float closeRot = 90f; // Close rotation set to 90 degrees
    public float speed = 1f;
    private bool _closed;
    public bool Closed
    {
        get { return _closed; }
        set
        {
            _closed = value;
            // Add any additional logic or functionality you need when the closed state changes
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRoot = Door.transform.localEulerAngles;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Closed = !Closed;
        }

        if (_closed)
        {
            if (currentRoot.y > closeRot)
            {
                Door.transform.localEulerAngles = Vector3.Lerp(currentRoot, new Vector3(currentRoot.x, closeRot, currentRoot.z), speed * Time.deltaTime);
            }
        }
        else
        {
            if (currentRoot.y < openRot)
            {
                Door.transform.localEulerAngles = Vector3.Lerp(currentRoot, new Vector3(currentRoot.x, openRot, currentRoot.z), speed * Time.deltaTime);
            }
        }
    }
}