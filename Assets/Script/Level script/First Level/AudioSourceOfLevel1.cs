using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceOfLevel1 : MonoBehaviour
{
    public static AudioSourceOfLevel1 instance { get; private set; }

    public AudioClip[] arraudio;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }
}
