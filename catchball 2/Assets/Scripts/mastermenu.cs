using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mastermenu : MonoBehaviour
{
    public InputField inputField;
    public GameObject Tokei;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void change_button()
    {
        PlayerPrefs.SetInt("HIGHSCORE_N", 0);
        PlayerPrefs.SetInt("HIGHSCORE_H", 0);
    }
}
