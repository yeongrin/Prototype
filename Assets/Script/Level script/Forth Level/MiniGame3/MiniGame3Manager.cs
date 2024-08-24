using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MiniGame3Manager : MonoBehaviour
{
    //StartSceneVideo
    public GameObject transitionVideo3;
    public VideoPlayer transitionV3;

    //EndSceneVideo
    public GameObject transitionVideo4;
    public VideoPlayer transitionV4;

    //Check video ending
    public static bool transitionV4start;
    private bool test = false;
    public GameObject miniGame3;
    public GameObject miniGame4;
    public GameObject carBackground;
    public GameObject nextBackground;

    CursorState _cs;

    private void Awake()
    {
        transitionV4start = false;
    }


    void Start()
    {
        _cs = FindObjectOfType<CursorState>();
    }

    void Update()
    {
        if (transitionV4start == true && test == false)
        {
            test = true;
            Invoke("EndVideoStart", 1.0f);
        }
    }

    public void EndVideoStart()
    {
        _cs.showCursor = CursorState.CursorShowing.Invisible;
        transitionVideo4.SetActive(true);
        transitionV4.loopPointReached += EndVideoCheckOver;
        StartCoroutine(Wait());
        
    }

    void EndVideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        
        miniGame4.SetActive(true);
        transitionVideo3.SetActive(false);
        transitionVideo4.SetActive(false);
        print("turnbed off videos");
        miniGame3.SetActive(false);
        _cs.showCursor = CursorState.CursorShowing.Visible;

    }

    IEnumerator Wait()
    {
        print("endingCar");
        _cs.showCursor = CursorState.CursorShowing.Invisible;
        yield return new WaitForSeconds(2f);
        carBackground.SetActive(false);
        nextBackground.SetActive(true);
    }
}
