using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Timer : MonoBehaviour
{
    float angle = 0;
    [SerializeField] GameObject orchestra,gameSys,Camera;
    [SerializeField] AudioClip clip;
    [SerializeField] TimelineAsset[] timelineAsset;
    RectTransform rect;
    AudioSource audioSource;
    Game.menu game;

    void OnEnable()
    {
        angle = 0;
    }
    void FixedUpdate()
    {
        rect = GetComponent<RectTransform>();
        audioSource = orchestra.GetComponent<AudioSource>();
        angle = 360 * (audioSource.time / clip.length);
        if(angle>=360)
        {
            Camera.GetComponent<PlayableDirector>().playableAsset=timelineAsset[1];
            Camera.GetComponent<PlayableDirector>().Play();
            gameSys.GetComponent<Game>().Menu=Game.menu.result;

        }
        rect.rotation = Quaternion.Euler(0, 0, -angle);
        //Debug.Log("ANgle" + angle);
    }
}
