using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class MouseVol : MonoBehaviour
{
    Vector3 pMousePos, pos;
    Vector3 mousePos;
    float acc, acc_arv, acc_sum, x_del, y_del;
    float seconds = 0;
    public  float volm;
    int count = 0;
    public Parameter parameter;
    XDirection xd, pxd;
    YDirection yd, pyd;
    public float[] BPM;
    [SerializeField] public float Intempo;
    float tempoTime, tempospeed, tempo = 0;
    [SerializeField] float StopSpeed;
    int tempocount, sec = 0;
    float mousespeed;
    float[] tempotimes = new float[4] { 0, 0, 0, 0 };
    bool stop = false;
    bool start=false;
    public AudioSource Audio;
    [SerializeField]AudioMixer audioMixer;
    [SerializeField] GameObject game,Cursor;
    Game.menu menu;
    //bool stop = false;
    //[SerializeField] GameObject Acc_text, PMousePos_text, MousePos_text;

    public enum Parameter
    {
        idle=0, utouto=1, sleep=2, Amazing=3
    }

    enum XDirection
    {
        Xposi, Xnega
    }
    enum YDirection
    {
        Yposi, Ynega
    }


    void Start()
    { 
        
    }
    void FixedUpdate()
    {
        menu = game.GetComponent<Game>().Menu;
        if(menu==Game.menu.gaming&&start==false)
        {
            StartCoroutine("Tempo");
            acc_sum = 0;
            BPM = new float[4] { Intempo, Intempo, Intempo, Intempo };
            Audio = GetComponent<AudioSource>();
            start = true;
        }
        mousePos = Input.mousePosition;
        mousespeed = Longer(Cursor.GetComponent<CursorMouses>().Axi);
        //Acc_text.GetComponent<TextMeshProUGUI>().text = acc_arv.ToString();
        //PMousePos_text.GetComponent<TextMeshProUGUI>().text = pMousePos.ToString();
        //MousePos_text.GetComponent<TextMeshProUGUI>().text = mousePos.ToString();
        //Direction();
        Accel();
        Music_vol();
        Direction();
        Audio.pitch = BPM.Average() / Intempo;
        audioMixer.SetFloat("Shifter",1/Audio.pitch);
    }

    IEnumerator Tempo()
    { 
        while (true)
        {
            pxd = xd;
            pyd = yd;
            tempoTime += 2 * Time.deltaTime;

            yield return null;

            if ((pxd != xd || pyd != yd) && mousespeed >= StopSpeed && !stop)
            {
                if (Time.time >= 3)
                {
                    tempocount++;
                    tempotimes[(tempocount + 4) % 4] = tempoTime;
                    tempoTime = 0;
                }
                stop = true;
            }
            else
            {
                stop = false;
            }
            //Debug.Log("TC:" + tempocount);

            if (tempocount >= 4)
            {
                if (32 <= 240 / tempotimes.Sum() && 240 / tempotimes.Sum() <= 252)
                {
                    BPM[tempocount % 4] = 240 / tempotimes.Sum();
                }
            }
        }
    }
    void Direction()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            xd = XDirection.Xposi;
        }
        else
        {
            xd = XDirection.Xnega;
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            yd = YDirection.Yposi;
        }
        else
        {
            yd = YDirection.Ynega;
        }
        //Debug.Log("yd:" + yd + "_xd:" + xd);
    }
    private void OnGUI()
    {
        //Rect rect = new Rect(10, 10, 1000, 1000);
        //Rect rect1 = new Rect(10, 20, 1000, 1000);
        //Rect rect2 = new Rect(10, 30, 1000, 1000);
        //GUI.Label(rect, "BPM;" + BPM.Average());
        //GUI.Label(rect1, "TC;" + tempocount);
        //GUI.Label(rect2, Longer(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")).ToString());
        //GUI.Label(new Rect(10, 40, 1000, 1000), tempotimes.Sum().ToString() + "TT");
    }
    void Accel()
    {
        x_del = Mathf.Pow(pMousePos.x - mousePos.x, 2);
        y_del = Mathf.Pow(pMousePos.y - mousePos.y, 2);
        seconds += Time.deltaTime;
        //Debug.Log("acc" + acc);
        if (seconds >= 1)
        {
            pMousePos = mousePos;
            acc = Mathf.Sqrt(x_del + y_del);
            count++;
            acc_sum += acc;
            acc_arv = acc_sum / count;
            if (count == 4)
            {
                count = 0;
                acc_sum = 0;
            }
            seconds = 0;
        }
    }
    void Music_vol()
    {
        volm = acc_arv / 1000;

        if (volm >= 1)
        {
            volm = 1;
        }

        else if (volm <= 0.1)
        {
            volm = 0.1f;
        }

       Audio.volume = volm;
    }
    float Longer(Vector2 vc)
    {
        float L=(vc.x*vc.x+vc.y*vc.y);
        return L;
    }
}
