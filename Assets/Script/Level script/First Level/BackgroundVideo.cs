using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BackgroundVideo : MonoBehaviour
{
    public VideoPlayer Bvideo;
    public GameObject dialogue1;
    public bool gameStart;

    void Start()
    {
       // gameStart = false;
    }


    void Update()
    {
        
    }
    
    void VideoStart()
    {
        /*if (gameStart == true)
        {
            Bvideo.gameObject.SetActive(true);
        }*/
    }
}
