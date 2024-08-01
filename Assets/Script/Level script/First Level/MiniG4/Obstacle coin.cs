using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Obstaclecoin : MonoBehaviour
{
    MiniGame4 _MG4;
    Animator ani;

    AudioSource audioSource;
    AudioClip sound;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sound = AudioSourceOfLevel1.instance.arraudio[1];
        audioSource.clip = sound;
    }

    public void Start()
    {
        ani = GetComponent<Animator>();
        _MG4 = GameObject.FindObjectOfType<MiniGame4>().GetComponent<MiniGame4>();
    }

    void Update()
    {
        if (_MG4.isChange == true)
        {
            ChangeFileColor();
        }
    }

    void ChangeFileColor()
    {
        ani.SetBool("timer", true);
    }

    public void DestroyObj()
    {
        StartCoroutine("SoundOutPut");
    }

    IEnumerator SoundOutPut()
    {
        audioSource.Play();
        _MG4.timer4 = 3f;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }
}
