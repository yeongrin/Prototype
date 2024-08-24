using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SoundEffectStop : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip sound;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        sound = AudioSourceOfLevel1.instance.arraudio[6];
        audioSource.clip = sound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.over5 == true)
            audioSource.Stop();
    }


}
