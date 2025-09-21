using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    string timeText;
    public  static int play_n=0;
    public  static int play_h=0;
    IEnumerator time()
    {
        int time = 3;
        Text CountDown_Text = GetComponent<Text>();
        for (int j = 0; j < 3; j++)//アニメーション
        {
            yield return new WaitForSeconds(1f);

            time = time - 1;

            timeText = time.ToString("0");
            CountDown_Text.text = timeText;

        }
        if (time <= 0 && TutorialSceneMove.difficulty_num == 0)
        {
            SceneManager.LoadScene("catchball2");
            play_n++;
            PlayerPrefs.SetInt("play_n", play_n);
        }
        if (time <= 0 && TutorialSceneMove.difficulty_num == 1)
        {
            SceneManager.LoadScene("hardmode");
            play_h++;
            PlayerPrefs.SetInt("play_h", play_h);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("time");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
