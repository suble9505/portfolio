using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class ballCtrl_h : MonoBehaviour
{
    int i = 1;
    float targetY = 0.28f;
    float randX;

    float f_score = 0.0f;
    void Start()
    {

    }

    void Update()
    {

        Vector3 pos = this.transform.position;

        MisscountScript misscountScript;
        GameObject misscountObj = GameObject.Find("misscountObj");
        misscountScript = misscountObj.GetComponent<MisscountScript>();

        playerCtrl PlayerCtrl;
        GameObject playerObj = GameObject.Find("player");
        PlayerCtrl = playerObj.GetComponent<playerCtrl>();

        friendCtrl_H FriendCtrl;
        GameObject friendObj = GameObject.Find("friend");
        FriendCtrl = friendObj.GetComponent<friendCtrl_H>();

        int score = PlayerCtrl.score;
        f_score = (float)score;
        if (pos.y >= -2.50)
        {
            transform.position = Vector3.MoveTowards(pos, new Vector3(randX, targetY, 0), 0.2f + f_score / 20);
        }
        else
        {
            transform.position = Vector3.MoveTowards(pos, new Vector3(pos.x, targetY, 0), 10);
        }

        if (pos.y <= targetY)
        {
            targetY = targetY - 0.1f * i;
            randX = Random.Range(-3f, 3f);
            i++;
        }



        if (pos.y < -5 || (pos.x < -3.5 && pos.x > 3.5))
        {
            Destroy(gameObject);
            FriendCtrl.friendball = 1;
            misscountScript.misscount++;
        }
    }
}