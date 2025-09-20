using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friendCtrl_H : MonoBehaviour
{
    private float _repeatSpan;
    private float _timeElapsed;

    public SpriteRenderer spriteRenderer;
    public Sprite[] FriendSprites = new Sprite[4];
    public GameObject ball;

    public AudioClip SE_pitching;
    public AudioClip SE_catch;
    AudioSource audioSource;

    public int friendball = 1; //ボールの所有判定(友達);

    int i = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    IEnumerator pitching()
    {
        i = 0;
        friendball = 0;

        for (int j = 0; j < 2; j++)//アニメーション
        {
            spriteRenderer.sprite = FriendSprites[i];
            i++;

            yield return new WaitForSeconds(0.25f);

            spriteRenderer.sprite = FriendSprites[i];
            i++;
        }
        yield return new WaitForSeconds(0.25f);
        int rnd = Random.Range(0, 13);
        Instantiate(ball, new Vector3(0, 0.38f, 0), Quaternion.identity);//発射
        audioSource.PlayOneShot(SE_pitching);


    }
    void Update()
    {
        if (friendball == 1)
        {
            StartCoroutine("pitching");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ReturnBall(Clone)")
        {
            Destroy(collision.gameObject);
            friendball = 1;
            audioSource.PlayOneShot(SE_catch);
        }
    }
}


// Update is called once per frame

