using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager4 : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject vidOb;
    public GameObject Map1;

    public AudioSource audioSource;

    CursorState _cs;

    void Start()
    {
        vid.loopPointReached += CheckOver;
        StartCoroutine("Delay");
        _cs = FindObjectOfType<CursorState>();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.5f);
        vid.Play();
        audioSource.Play();
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        _cs.showCursor = CursorState.CursorShowing.Visible;
        Map1.SetActive(true);
        //GameObject.Find("Game").transform.Find("Scene1").processingObject.SetActive(false);
        vidOb.SetActive(false); ;
        
    }
}
