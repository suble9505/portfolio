using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMouse : MonoBehaviour
{
    [SerializeField] public float sensitivity = 2.0f; 
    Vector3 cursorPos;

    void Start()
    {
       cursorPos = Input.mousePosition;
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Mouse X");
        float deltaY = Input.GetAxis("Mouse Y");

        cursorPos += new Vector3(deltaX, deltaY, 0) * sensitivity;

        cursorPos.x = Mathf.Clamp(cursorPos.x, 0, Screen.width);
        cursorPos.y = Mathf.Clamp(cursorPos.y, 0, Screen.height);

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
}
