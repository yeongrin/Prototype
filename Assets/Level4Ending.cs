using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Level4Ending : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public GameObject endButton;
    public AudioSource audioSource;

    CursorState _cs;

    void Start()
    {
        VideoPlayer.loopPointReached += CheckOver;
        _cs = FindObjectOfType<CursorState>();
    }

    
    void Update()
    {
        
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        endButton.SetActive(true);
        _cs.showCursor = CursorState.CursorShowing.Visible;
    }
}
