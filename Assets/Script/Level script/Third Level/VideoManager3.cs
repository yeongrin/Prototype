using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager3 : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject vidOb;
    public GameObject Map2;

    // Start is called before the first frame update
    void Start()
    {
        vid.loopPointReached += CheckOver;
        vid.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        
        GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
        vidOb.SetActive(false); ;
    }
}
