using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class ballCtrl : MonoBehaviour
{
    private float rnd_speed_Delta = 1;
    void Start()
    {
        SplineAnimate splineAnimate;
        splineAnimate = GetComponent<SplineAnimate>();

        playerCtrl PlayerCtrl;
        GameObject playerObj = GameObject.Find("player");
        PlayerCtrl = playerObj.GetComponent<playerCtrl>();

        if (PlayerCtrl.score < 5)
        {
            rnd_speed_Delta = Random.Range(0.9f, 1.0f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 5)
        {
            rnd_speed_Delta = Random.Range(0.9f, 1.0f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 10)
        {
            rnd_speed_Delta = Random.Range(0.75f, 1.0f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 15)
        {
            rnd_speed_Delta = Random.Range(1.0f, 0.95f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 20)
        {
            rnd_speed_Delta = Random.Range(0.75f, 1.0f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 25)
        {
            rnd_speed_Delta = Random.Range(1.0f, 0.9f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 30)
        {
            rnd_speed_Delta = Random.Range(0.75f, 1.0f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 35)
        {
            rnd_speed_Delta = Random.Range(0.9f, 0.9f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 50)
        {
            rnd_speed_Delta = Random.Range(0.7f, 0.8f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 75)
        {
            splineAnimate.Duration = 3f;
            rnd_speed_Delta = Random.Range(0.3f, 0.6f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 100)
        {
            splineAnimate.Duration = 3f;
            rnd_speed_Delta = Random.Range(0.25f, 0.5f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 150)
        {
            splineAnimate.Duration = 3f;
            rnd_speed_Delta = Random.Range(0.2f, 0.5f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
        if (PlayerCtrl.score >= 200)
        {
            splineAnimate.Duration = 3f;
            rnd_speed_Delta = Random.Range(0.1f, 0.3f);
            splineAnimate.Duration = splineAnimate.Duration * rnd_speed_Delta;
        }
    }
    void Update()
    {
        Vector3 pos = this.transform.position;

        MisscountScript misscountScript;
        GameObject misscountObj = GameObject.Find("misscountObj");
        misscountScript = misscountObj.GetComponent<MisscountScript>();

        friendCtrl FriendCtrl;
        GameObject friendObj = GameObject.Find("friend");
        FriendCtrl = friendObj.GetComponent<friendCtrl>();


        if (pos.y < -5 || (pos.x < -3.5 && pos.x > 3.5))
        {
            Destroy(gameObject);
            FriendCtrl.friendball = 1;
            misscountScript.misscount++;
        }
    }
}