using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public int numberValue;
    int currentNumber;
    public VideoPlayer vid;
    public VideoPlayer backvid;
    public GameObject vidOb;
    public GameObject backvidOb;

    void Start() 
    { 
        
        vid.loopPointReached += CheckOver;
        Invoke("OnInvoke", 0.5f);
    
    }

    void OnInvoke()
    {
        vid.Play();
    }

    private void Update()
    {
        if (numberValue != currentNumber)
        {
            switch (numberValue)
            {
                case 1:
                    vid.Play();
                    break;

                case 2:
                    vid.Pause();
                    break;
            }
        }

        currentNumber = numberValue;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        vidOb.SetActive(false);
    }
}
