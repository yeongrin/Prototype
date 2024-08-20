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
    AudioSource audioSourceFinal;
    public AudioSource carSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSourceFinal = GetComponent<AudioSource>();
        ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        ppVolume.weight = 0;
        video.loopPointReached += CheckOver;
        videoOver = false;
        StartCoroutine(PlayCarSounds());
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
        Cursor.visible = true;
        videoOver = true;
        audioSourceFinal.Stop();
        carSource.Stop();
    }

    public IEnumerator PlayCarSounds()
    {
        yield return new WaitForSeconds(4);
        audioSourceFinal.Play();
    }
}
