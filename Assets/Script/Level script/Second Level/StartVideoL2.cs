using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartVideoL2 : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject vidOb;
    public GameObject credits;
    public Animator ani;
    public float timer;
    bool creditsTimer;

    BackToMain _btm;

    [Header ("Fade")]
    RawImage image;
    private bool checkbool = false;

    void Start()
    {
        vid.loopPointReached += CheckOver;
        image = GetComponent<RawImage>();
        StartCoroutine("Delay");
        creditsTimer = false;
        _btm = FindObjectOfType<BackToMain>();
    }

    void Update()
    {
        if (creditsTimer)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
            _btm.SceneLoad();

        /*if (checkbool)
        {
            game.SetActive(true);
            vidOb.SetActive(false);

        }*/
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3.0f);
        vid.Play();
    }

    void OnInvoke()
    {
        vid.Play();
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //StartCoroutine("MainSplash");
        credits.SetActive(true);
        vidOb.SetActive(false);
        ani.SetTrigger("Fadeout");
        creditsTimer = true;
    }

    /*IEnumerator MainSplash()
    {

        Color color = image.color;

        for (int i = 0; i <= 150; i++)
        {

            color.a -= Time.deltaTime * 0.01f;

            image.color = color;

            if (image.color.a >= 0)
            {
                checkbool = true;
            }
        }
    
        yield break;
    }*/
}