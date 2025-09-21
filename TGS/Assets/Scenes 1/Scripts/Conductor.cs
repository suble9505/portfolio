using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // Start is called before the first frame updat
    MouseVol mouseVol;
    [SerializeField] GameObject mouse;
    [SerializeField] Animator[] anim;
    float bpm;

    float volm;
    void Start()
    {
        mouseVol = mouse.GetComponent<MouseVol>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseVol = mouse.GetComponent<MouseVol>();
        volm = mouseVol.volm;
        bpm = mouseVol.BPM.Average();
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("speed", bpm / 120);
        }
        if (volm >= 0.8)
        {
            anim[0].SetInteger("param", 2);
            for (int i = 0; i < anim.Length - 1; i++)
            {
                anim[i + 1].SetInteger("vol", 1);
            }
        }
        else if (volm <= 0.2)
        {
            anim[0].SetInteger("param", 0);
            for (int i = 0; i < anim.Length - 1; i++)
            {
                anim[i + 1].SetInteger("vol", 0);
            }
        }
        else
        {
            anim[0].SetInteger("param", 1);
        }
    }
}
