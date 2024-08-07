using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndVideo : MonoBehaviour
{
    public int numberValue;
    int currentNumber;
    public VideoPlayer vid;
    public VideoPlayer vid2;
    public GameObject vidOb;
    public GameObject game2;
   
    void Start() 
    { 
        
        vid.loopPointReached += CheckOver;
        //Invoke("OnInvoke", 0.5f);
    
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
        vid2.Play();
        vid2.loopPointReached += CheckOver2;
    }

    void CheckOver2(UnityEngine.Video.VideoPlayer vp2)
    {
        game2.SetActive(true);
    }
}
