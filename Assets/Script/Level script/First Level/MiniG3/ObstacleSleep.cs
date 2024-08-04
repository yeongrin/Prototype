using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSleep : MonoBehaviour
{
    Animator animator;
    private Transform Button3;

    AudioClip sound;
    AudioSource audioSource;

    void Start()
    {
        Button3 = GameObject.FindGameObjectWithTag("Object3").transform;
        animator = GetComponent<Animator>();

        audioSource = gameObject.GetComponent<AudioSource>();
        sound = AudioSourceOfLevel1.instance.arraudio[3];
        sound = AudioSourceOfLevel1.instance.arraudio[4];
        audioSource.clip = sound;
    }

    public void StartAnimation()
    {
        audioSource.Play();
        animator.SetTrigger("WakeUp");
    }
}

