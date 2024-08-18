using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTransition2 : MonoBehaviour
{
    public VideoPlayer transitionVid;
    public GameObject transitionVidOb;
    public GameObject game2;
    //public SpawnFlies spawnFlies;

    void Start()
    {
        transitionVid.loopPointReached += CheckOver;
        transitionVid.Play();
    }

    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("132542356363");
        game2.SetActive(true);
        transitionVidOb.SetActive(false);
    }
}
