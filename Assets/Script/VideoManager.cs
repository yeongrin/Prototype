using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public int numberValue;
    int currentNumber;
    public GameObject vid;
    public VideoPlayer vidOb;
    public GameObject secondVid;
    public VideoPlayer vidOb2;

    public AudioSource audioSource;

    void Start() 
    {
       
        vidOb.loopPointReached += CheckOver;

        StartCoroutine("Delay");

    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        vidOb.Play();
        audioSource.Play();
    }

    private void Update()
    {
        
        if (numberValue != currentNumber)
        {
            switch (numberValue)
            {
                case 1:
                    vidOb.Play();
                    break;

                case 2:
                    vidOb.Pause();
                    break;
            }
        }

        currentNumber = numberValue;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        secondVid.SetActive(true);
        vid.SetActive(false);
    }
}
