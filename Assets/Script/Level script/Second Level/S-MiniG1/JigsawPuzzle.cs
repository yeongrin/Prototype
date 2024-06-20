using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JigsawPuzzle : MonoBehaviour
{
    public static Action JP;

    public GameObject puzzlePosSet;
    public GameObject puzzlePieceSet;
    public GameObject endingVideo;

    private void Awake()
    {
        JP = () => { VideoStart(); };
    }

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsClear()
    {
        for(int i = 0; i<puzzlePosSet.transform.childCount;i++)
        {
            if(puzzlePosSet.transform.GetChild(i).childCount == 0)
            {
               
                return false;

            }
        if (puzzlePosSet.transform.GetChild(i).GetChild(0).GetComponent<PuzzleGame>().piece_no != i)
        {
            return false;
        }

        }
         
        ChangeColor.CC();
       
        return true;
    }

    public void VideoStart()
    {
        //GameObject.Find("AllMap").transform.Find("BackGroundVideo").gameObject.SetActive(true);
        endingVideo.SetActive(true);
    }

}
