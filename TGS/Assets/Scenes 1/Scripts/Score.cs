using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{ 
    // Start is called before the first frame update
    public int score;
    //[SerializeField]  GameObject ScoreTxt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ScoreTxt.GetComponent<TextMeshProUGUI>().text=score.ToString();
    }
}
