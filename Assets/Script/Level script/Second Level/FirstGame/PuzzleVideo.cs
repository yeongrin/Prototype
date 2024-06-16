using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PuzzleVideo : MonoBehaviour
{
    public VideoPlayer endingvid;
    public GameObject endingvidOb;

    // Start is called before the first frame update
    void Start()
    {
        endingvid.loopPointReached += CheckOver;
        endingvid.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        //endingvidOb.SetActive(false);
    }
}
