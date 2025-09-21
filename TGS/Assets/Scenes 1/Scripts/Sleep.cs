using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;
using UnityEngine.SceneManagement;
public class Sleep : MonoBehaviour
{
    [SerializeField] float WakeUp_vol;
    [SerializeField] int WakeUp_kakuritu;
    [SerializeField] GameObject orchestra, game, zzz, bikkuri;
    [SerializeField] AnimationClip[] clips;
    public int wakeUp;
    MouseVol.Parameter[] parameters = (MouseVol.Parameter[])Enum.GetValues(typeof(MouseVol.Parameter));



    Animator animator;
    MouseVol mouse;
    GameObject GameCtrl;
    //SpriteRenderer Sp;
    MouseVol.Parameter Parameter;
    float volm;
    int score;
    bool sleeped, amazing = false;
    bool effected = false;

    Vector2 pos;

    // Start is called before the first frame update

    void Start()
    {
        animator = this.GetComponent<Animator>();
        mouse = orchestra.GetComponent<MouseVol>();
        pos = transform.position;
        GameCtrl = GameObject.Find("gameCtrl");


    }
    void Update()
    {
        if (GameCtrl.GetComponent<Game>().Menu == Game.menu.gaming)
        {
            volm = mouse.volm;
            //Sp=GetComponent<SpriteRenderer>();
            Animation();
            Deleffect(sleeped, zzz);
            Deleffect(amazing, bikkuri);

            if (WakeUp_vol - 0.7f <= volm && volm < WakeUp_vol - 0.5
                //&& Parameter == MouseVol.Parameter.idle
                )
            {
                Parameter = MouseVol.Parameter.utouto;
            }
            else if (volm >= WakeUp_vol)
            {
                if (!amazing)
                {
                    wakeUp = UnityEngine.Random.Range(0, 10);
                    amazing = true;
                }

                if (wakeUp <= WakeUp_kakuritu
                    //&& Parameter== MouseVol.Parameter.sleep
                    )
                {
                    if (sleeped)
                    {
                        Parameter = MouseVol.Parameter.Amazing;
                        Effect(amazing, bikkuri);
                        float rnd = UnityEngine.Random.Range(1.0f, 2.0f);
                        game.GetComponent<Score>().score += (int)(100 * rnd);
                        sleeped = false;
                    }

                }
                //Sp.sprite = Visitors[0];
            }
            else if (volm < WakeUp_vol - 0.7f
                //&& (Parameter != MouseVol.Parameter.sleep)
                )
            {
                sleeped = true;
                Parameter = MouseVol.Parameter.sleep;
                Effect(sleeped, zzz);
                amazing = false;
            }
            else if
                (
                //Parameter != MouseVol.Parameter.idle&&
                WakeUp_vol - 0.7f <= volm && !sleeped
                //&&Parameter!=MouseVol.Parameter.Amazing
                )

            {
                ToIdle();
                amazing = false;
            }
            //Debug.Log(volm + "volm");
            //orchestra.GetComponent<MouseVol>().parameter = Parameter;

            //if (Input.GetMouseButtonDown(2))
            //{
            //    SceneManager.LoadScene("Menu");
            //}
            orchestra.GetComponent<MouseVol>().parameter = Parameter;
        }
    }


    void ToIdle()
    {
        Parameter = MouseVol.Parameter.idle;
    }

    void Animation()
    {
        animator.SetInteger("parameter", (int)Parameter);
        //Debug.Log(Parameter + (int)Parameter);
    }
    void Effect(bool cond, GameObject str)
    {
        if (GameCtrl.GetComponent<Game>().Menu == Game.menu.gaming && !effected)
        {
            if (cond)
            {
                Instantiate(str,
                    new Vector3(pos.x - 0.2f, pos.y + 0.4f, GetComponentInParent<Transform>().position.z)
                    , Quaternion.identity, transform);
                effected = true;
            }
        }
    }
    void Deleffect(bool cond, GameObject str)
    {
        if (!cond)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag == str.name)
                {
                    Destroy(transform.GetChild(i).gameObject);
                    effected = false;
                    break;
                }
            }
        }
    }


}
