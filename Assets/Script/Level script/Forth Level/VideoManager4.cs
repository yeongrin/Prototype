using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager4 : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject vidOb;
    public GameObject Map1;

    void Start()
    {
        vid.loopPointReached += CheckOver;
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        vid.Play();
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");

        Map1.SetActive(true);
        //GameObject.Find("Game").transform.Find("Scene1").processingObject.SetActive(false);
        vidOb.SetActive(false); ;
    }
}
