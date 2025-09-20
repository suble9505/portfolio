using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneMove : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
