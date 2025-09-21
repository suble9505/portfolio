using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class playerCtrl_N : MonoBehaviour
{
    public int score = 0;

    private GameObject ScoreText;

    public int playerball = 0;//ボールの所有判定(0:無、1:有)(プレイヤー)

    public GameObject ReturnBall;

    public GameObject[] balls = new GameObject[12];
    public SpriteRenderer spriteRenderer;
    public Sprite[] PlayerSprites = new Sprite[3];

    int i = 0;
    Vector3 mousePos, worldPos;

    public AudioClip catch_SE;
    public AudioClip pitching_SE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText");
        audioSource = GetComponent<AudioSource>();
    }
    IEnumerator ReturnPitching()
    {
        playerball = 0;
        i = 0;
        Vector3 pos = this.transform.position;
        for (int j = 0; j < 3; j++)//アニメーション
        {
            spriteRenderer.sprite = PlayerSprites[i];
            i++;

            yield return new WaitForSeconds(0.25f);
        }

        Instantiate(ReturnBall, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        audioSource.PlayOneShot(pitching_SE);
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = PlayerSprites[0];

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos, pos;
        mousePos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        if (pos.y <= 0 && Input.GetMouseButton(0))
        {
            if (pos.x - 1 <= transform.position.x && transform.position.x <= pos.x + 1)
            {
                if (-3.5 < transform.position.x && transform.position.x < 3.5)
                {
                    pos = new Vector3(pos.x, -2.56f, 10f);

                    transform.position = pos;
                }
            }
        }

        if (playerball == 1)
        {
            StartCoroutine("ReturnPitching");
        }
    }
    void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "MovingBall")
        {
            Destroy(collsion.gameObject);
            playerball = 1;
            score++;
            ScoreText.GetComponent<ScoreManager>().Score = ScoreText.GetComponent<ScoreManager>().Score + 1;
            audioSource.PlayOneShot(catch_SE);
        }
    }
}
