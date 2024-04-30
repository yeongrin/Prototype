using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager3 : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject vidOb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        GameObject.Find("Game").transform.Find("Scene2").gameObject.SetActive(true);
        GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
    }
}
