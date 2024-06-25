using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JigsawPuzzle2 : MonoBehaviour
{
    public static Action JP2;

    public GameObject puzzlePosSet;
    public GameObject puzzlePieceSet;
    public GameObject endingPanel;

    private void Awake()
    {
        JP2 = () => { VideoStart(); };
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
        if (puzzlePosSet.transform.GetChild(i).GetChild(0).GetComponent<PuzzleGame2>().piece_no != i)
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
        endingPanel.SetActive(true);
    }

}
