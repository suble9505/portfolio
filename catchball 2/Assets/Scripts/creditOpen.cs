using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creditOpen : MonoBehaviour
{
    public GameObject credits;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void change_button()
    {
        credits.SetActive(true);
    }
}
