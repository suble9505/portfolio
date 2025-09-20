using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tokei : MonoBehaviour
{   
     [SerializeField] private GameObject outObj;
     private Text outText;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        outText = outObj.GetComponent<Text>();
        if(outObj.name=="play_num_n_out")
        {
            outText.text = PlayerPrefs.GetInt("play_n", 0).ToString("f1");
        }
         if(outObj.name=="play_num_h_out")
        {
             outText.text = PlayerPrefs.GetInt("play_h", 0).ToString("f1");
        }
       if(outObj.name=="avg_n_out")
        {
            outText.text = PlayerPrefs.GetInt("Avg_n", 0).ToString("f1");
        }
        if(outObj.name=="avg_h_out")
        {
             outText.text= PlayerPrefs.GetInt("Avg_h", 0).ToString("f1");
        }
    }
}
