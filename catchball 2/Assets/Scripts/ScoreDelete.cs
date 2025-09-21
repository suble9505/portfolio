using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDelete : MonoBehaviour
{

    public void OnClick()
    {
        Debug.Log("スコアが０になったら成功！！");
        PlayerPrefs.SetInt("HIGHSCORE", 0);
    }
}
