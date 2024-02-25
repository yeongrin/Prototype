using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video1 : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public bool isChanged;
    public VideoClip[] videoClips;
    int indexNumber;

    // Start is called before the first frame update
    void Awake()
    {
        indexNumber = 0;
        videoPlayer = GetComponent<VideoPlayer>();
        SetVideo();
        
    }

    // Update is called once per frame
    public void SetVideo()
    {
        if (indexNumber < videoClips.Length)
        {
            videoPlayer.clip = videoClips[indexNumber];
            indexNumber++;
        }
        else
            videoPlayer.clip = null;
    }

    public IEnumerator FadeIn()
    {
        isChanged = false;
        while (videoPlayer.targetCameraAlpha > 0.99f)
        {
            videoPlayer.targetCameraAlpha += 0.025f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator FadeOut()
    {
        while (videoPlayer.targetCameraAlpha > 0.01f)
        {
            videoPlayer.targetCameraAlpha -= 0.025f;
            yield return new WaitForSeconds(0.01f);
        }
        isChanged = true;
    }
}
