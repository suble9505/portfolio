using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMouses : MonoBehaviour
{
    [SerializeField] public float sensitivity = 2.0f; 
    private Vector2 cursorPos;
    public Vector2 Axi;


    IEnumerator Start()
    {
        cursorPos = Input.mousePosition;
        while (true)
        {
            yield return null;
            float deltaX = Input.GetAxis("Mouse X");
            float deltaY = Input.GetAxis("Mouse Y");

            cursorPos += new Vector2(deltaX, deltaY) * sensitivity;

            cursorPos.x = Mathf.Clamp(cursorPos.x, 0, Screen.width);
            cursorPos.y = Mathf.Clamp(cursorPos.y, 0, Screen.height);

            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Cursor.visible = false;
            GetComponent<RectTransform>().position = cursorPos;

            StartCoroutine("Ax");
            yield return null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            cursorPos = new Vector2(Screen.width/2,Screen.height/2);
        }
    }

    //void Update()
    //{
    //    float deltaX = Input.GetAxis("Mouse X");
    //    float deltaY = Input.GetAxis("Mouse Y");

    //    cursorPos += new Vector2(deltaX, deltaY) * sensitivity;

    //    cursorPos.x = Mathf.Clamp(cursorPos.x, 0, Screen.width);
    //    cursorPos.y = Mathf.Clamp(cursorPos.y, 0, Screen.height);

    //    //Cursor.lockState = CursorLockMode.Locked;
    //    //Cursor.visible = false;
    //    GetComponent<RectTransform>().position = cursorPos;
    //}

    public  IEnumerator Ax()
    {
        Axi.x = cursorPos.x;
        Axi.y= cursorPos.y;
        yield return null;
        Axi.x -=cursorPos.x;
        Axi.y-=cursorPos.y;
    }
}
