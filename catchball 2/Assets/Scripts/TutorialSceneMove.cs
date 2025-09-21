using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneMove : MonoBehaviour
{
    public static int difficulty_num = 0;
    public GameObject Todifficulty;
    void Update()
    {

    }
    public void change_button()
    {
        if (Todifficulty.name == "Start_N")
        {
            difficulty_num = 0;
        }
        if (Todifficulty.name == "Start_H")
        {
            difficulty_num = 1;
        }
        SceneManager.LoadScene("tutorial");
    }
}
