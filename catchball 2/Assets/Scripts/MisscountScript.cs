using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MisscountScript : MonoBehaviour
{
    public int misscount = -1;
    public GameObject[] ObjectBalls = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (misscount > 2)
        {
            SceneManager.LoadScene("TitleScene");
        }
        if (misscount > -1 && misscount <= 2)
        {
            Destroy(ObjectBalls[misscount]);
        }
    }
}
