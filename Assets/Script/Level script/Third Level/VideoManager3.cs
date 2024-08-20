using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager3 : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject vidOb;
    public GameObject Map2;
    public GameObject Map3;
    PhotoLoader _Pl;

    // Start is called before the first frame update
    void Start()
    {
        vid.loopPointReached += CheckOver;
        vid.Play();
        _Pl = FindObjectOfType<PhotoLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        Cursor.visible = true;
        

        if(_Pl.photosTaken > 0)
        {
            Map2.SetActive(true);
            GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
            vidOb.SetActive(false);
        }
        else
        {
            Map3.SetActive(true);
            GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
            vidOb.SetActive(false);
        }
            
        
    }
}
