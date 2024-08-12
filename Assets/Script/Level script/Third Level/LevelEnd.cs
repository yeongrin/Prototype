using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Video;

public class LevelEnd : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject nextButton;
    PostProcessVolume ppVolume;
    bool videoOver;
    
    // Start is called before the first frame update
    void Start()
    {
        ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        ppVolume.weight = 0;
        video.loopPointReached += CheckOver;
        videoOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(videoOver == true && ppVolume.weight < 1)
        //{
        //    ppVolume.weight += Time.deltaTime;
        //}
        
    }

    public void CheckOver(UnityEngine.Video.VideoPlayer player)
    {
        nextButton.SetActive(true);
        videoOver = true;
    }
}
