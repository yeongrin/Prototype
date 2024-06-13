using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndingGame : MonoBehaviour
{
    public GameObject endingGame;
    public GameObject game;
    public GameObject endingVideo2;
    public GameObject nextPanel;
    public VideoPlayer endingVideo1;

    void Start()
    {
        endingVideo1.loopPointReached += CheckOver1;
        //Debug.Log("3534647");
    }

    void Update()
    {
    
        
    }

    void CheckOver1(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video end");
        endingGame.SetActive(true);
        game.SetActive(false);
    }

    void EndingVideoStart()
    {
        
    }
}
