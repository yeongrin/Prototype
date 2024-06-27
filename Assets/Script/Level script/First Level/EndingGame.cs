using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndingGame : MonoBehaviour
{
    public GameObject endingGame;
    public VideoPlayer endingVideo1;
    

    void Start()
    {
        endingVideo1.loopPointReached += CheckOver1;
    }

    void Update()
    {

    }

    void CheckOver1(UnityEngine.Video.VideoPlayer vp)
    {
        endingGame.SetActive(true);
    }
}
