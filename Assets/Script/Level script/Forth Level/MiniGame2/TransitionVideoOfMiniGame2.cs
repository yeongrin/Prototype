using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TransitionVideoOfMiniGame2 : MonoBehaviour
{
    public VideoPlayer transitionVid; //Transition video
    public GameObject transitionVidOb;
    public GameObject game2;
    public GameObject lastMinigame;
    public GameObject nextBackground;
    public GameObject gameThingy;

    void Start()
    {
        transitionVid.loopPointReached += CheckOver;
        transitionVid.Play();
        if (nextBackground != null)
        {
            nextBackground.SetActive(true);
        }
        else
            return;
        
        
    }

    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        game2.SetActive(true);
        //Spawning flies when video is over
        transitionVidOb.SetActive(false);
        if (lastMinigame != null)
        {
            lastMinigame.SetActive(false);
        }
        else
            return;
        if (gameThingy != null)
        {
            gameThingy.SetActive(true);
        }
        else
            return;
        
    }
}
