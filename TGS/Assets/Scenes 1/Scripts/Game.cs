using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject StartSystems,gameSystems,orchestra,resultSystem;
    public enum menu
    {
        gaming, result, Op
    }
    public menu Menu = menu.Op;
    void Update()
    {
        switch (Menu)
        {
            case menu.gaming:
                Time.timeScale = 1;
                gameSystems.SetActive(true);
                orchestra.SetActive(true);
                StartSystems.SetActive(false);
                resultSystem.SetActive(false);
                break;
            case menu.result:
                Time.timeScale = 0;
                StartSystems.SetActive(false);
                gameSystems.SetActive(false);
                resultSystem.SetActive(true);
                orchestra.SetActive(false);
                break;
            case menu.Op:
                Time.timeScale = 0;
                StartSystems.SetActive(true);
                gameSystems.SetActive(false);
                orchestra.SetActive(false);
                resultSystem.SetActive(false);
                break;
        }
    }
}