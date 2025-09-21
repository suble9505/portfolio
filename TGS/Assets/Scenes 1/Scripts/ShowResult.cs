using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    [SerializeField] public GameObject[] Show;
    [SerializeField] GameObject gameCtrl, Score,cam;
    [SerializeField] float RoopSpeed, showSpeed;
    [SerializeField]string Result="afe";
    int showed = 0;
    bool Start,ch = false;

    void OnEnable()
    {
        cam.GetComponent<PlayableDirector>().Play();
        showed = 0;
        Result = Score.GetComponent<Score>().score.ToString();
        while(Result.Length < Show.Length)
        {
            Result = "0" + Result;
        }
        StartCoroutine("Loop");
        //StartCoroutine("Inputs");
        Start = true;
    }
    private void Update()
    {
        if (Start && Input.anyKeyDown&&!ch)
        {
            StartCoroutine("Shows");
            ch = true;
        }
    }
    IEnumerator Loop()
    {
        while (true)
        {
            yield return null;
            for (int i = 0; i < 10; i++)
            {
                for (int j = showed; j < Show.Length; j++)
                {
                    //Debug.Log("j:" + j + "i:" + i);
                    Show[j].GetComponent<TextMeshProUGUI>().text = i.ToString();
                }
                yield return new WaitForSecondsRealtime(RoopSpeed);
                if (i >= 9)
                {
                    i = 0;
                }
            }
        }
    }
    IEnumerator Shows()
    {
        for (int i = 0; i < Show.Length; i++)
        {
            Debug.Log(Result[1]);
            Show[i].GetComponent<TextMeshProUGUI>().text
            = Result[Show.Length  - (i+1)].ToString();
            showed++;
            yield return new WaitForSecondsRealtime(showSpeed);
        }
        while (true)
        {
            yield return null;
            if (Input.anyKeyDown)
            { 
                ch=false;
                gameCtrl.GetComponent<Game>().Menu = Game.menu.Op;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
