using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    private Transform Button;

    AudioSource audioSource;
    AudioClip sound;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        sound = AudioSourceOfLevel1.instance.arraudio[2];
        audioSource.clip = sound;

        Button = GameObject.FindGameObjectWithTag("Object2").transform;
       
    }


    public void DestroyObj()
    {
        audioSource.Play();
        Destroy(GameObject.FindGameObjectWithTag("Enemy2"));
    }
}
