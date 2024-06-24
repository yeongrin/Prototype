using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public int numberValue;
    int currentNumber;
    public VideoPlayer vid;
    public GameObject vidOb;
    public GameObject secondVid;
    public VideoPlayer vidOb2;

    void Start() 
    {
        vid.loopPointReached += CheckOver;
        //vid.Play();

        //Play video when fade out ends.
        //Invoke("OnInvoke", 5f);
        StartCoroutine("Delay");


    }

   /*void OnInvoke()
    {
        vid.Play();
    }*/

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3.5f);
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
        secondVid.SetActive(true);
        vidOb.SetActive(false);
    }
}
