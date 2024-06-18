using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartVideo : MonoBehaviour
{
    public int numberValue;
    int currentNumber;
    public VideoPlayer vid;
    public GameObject vidOb;

    //private GameManager UI;
   // private AllMap AM;

    void Start()
    {
        // UI = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
       // AM = GameObject.FindObjectOfType<AllMap>().GetComponent<AllMap>();
        vid.loopPointReached += CheckOver;
        Invoke("OnInvoke", 0.5f);

    }

    void OnInvoke()
    {
        vid.Play();
    }

    private void Update()
    {
        if (numberValue != currentNumber)
        {
            switch (numberValue)
            {
                case 1:
                    vid.Play();
                    break;

                case 2:
                    vid.Pause();
                    break;
            }
        }

        currentNumber = numberValue;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        
        GameObject.Find("AllMap").transform.Find("Map1").gameObject.SetActive(true);
        vidOb.SetActive(false);
    }
}