using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartVideoL2 : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject vidOb;
    public GameObject game;

    [Header ("Fade")]
    RawImage image;
    private bool checkbool = false;

    void Start()
    {
        vid.loopPointReached += CheckOver;
        image = GetComponent<RawImage>();
        StartCoroutine("Delay");
    }

    void Update()
    {
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
        game.SetActive(true);
        vidOb.SetActive(false);

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