using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public int numberValue;
    int currentNumber;
    public VideoPlayer vid;

    void Start() 
    { 
        
        vid.loopPointReached += CheckOver; 
    
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
        Destroy(gameObject);
    }
}
