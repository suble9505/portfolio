using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private Text ScoreText;
    public int Score = 0;
    public GameObject score_object;
    float Avg_n;
    float Avg_h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDown countDown =GetComponent<CountDown>();
        
        ScoreText = GetComponentInChildren<Text>();
        if (SceneManager.GetActiveScene().name == "catchball2")
        {
            Debug.Log("プレイシーン");
            ScoreText.text = "0";
        }
        if (SceneManager.GetActiveScene().name == "hardmode")
        {
            Debug.Log("hardmode");
            ScoreText.text = "0";
        }
        else if (SceneManager.GetActiveScene().name == "TitleScene" && score_object.name == "HighScore_N")
        {
            Debug.Log("タイトルシーン");
            ScoreText.text = PlayerPrefs.GetInt("HIGHSCORE_N", 0).ToString();
        }
        else if (SceneManager.GetActiveScene().name == "TitleScene" && score_object.name == "HighScore_H")
        {
            Debug.Log("タイトルシーン");
            ScoreText.text = PlayerPrefs.GetInt("HIGHSCORE_H", 0).ToString();
        }

        if (SceneManager.GetActiveScene().name == "catchball2")
        {   
            PlayerPrefs.SetFloat("Total_n",Score+PlayerPrefs.GetFloat("Total_n", 0));
            Avg_n=PlayerPrefs.GetFloat("Total_n",0)/CountDown.play_n;
            PlayerPrefs.SetFloat("Avg_n",Avg_n);
            ScoreText.text = Score.ToString("");
            if (Score > PlayerPrefs.GetInt("HIGHSCORE_N", 0))
            {
                PlayerPrefs.SetInt("HIGHSCORE_N", Score);
            }
        }
        if (SceneManager.GetActiveScene().name == "hardmode")
        {   
            PlayerPrefs.SetFloat("Total_h",Score+PlayerPrefs.GetFloat("Total_h", 0));
            Avg_h=PlayerPrefs.GetFloat("Total_h",0)/(float)CountDown.play_h;
            PlayerPrefs.SetFloat("Avg_h",Avg_h);
            ScoreText.text = Score.ToString("");
            if (Score > PlayerPrefs.GetInt("HIGHSCORE_H", 0))
            {
                PlayerPrefs.SetInt("HIGHSCORE_H", Score);
            }
        }


    }
}
