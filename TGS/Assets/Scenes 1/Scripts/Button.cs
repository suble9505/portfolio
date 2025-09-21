using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class Button : MonoBehaviour
{
    // Start is called before the first frame u
    Game.menu menu;
    [SerializeField] GameObject game, Camera;
    [SerializeField] TimelineAsset timelineAsset;
    void Start()
    { 
        menu = game.GetComponent<Game>().Menu;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            OnButton();
        }
    }
    public void OnButton()
    {
        menu = Game.menu.gaming;
        Camera.GetComponent<PlayableDirector>().playableAsset = timelineAsset;
        Camera.GetComponent<PlayableDirector>().Play();
        game.GetComponent<Game>().Menu = menu;
    }
}
