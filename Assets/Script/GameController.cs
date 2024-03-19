using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;


public class GameController : MonoBehaviour
{
    public TMP_Text Daytext;
    public TMP_Text scoretext;
    public int score = 0;
    public Vector2 createPoint;

    public GameObject canvas;

    public GameObject[] inGameElements;

    public GameObject element1;
    public GameObject element2;
    public GameObject element3;
    public GameObject element4;
    public GameObject element5;

    public GameObject[] slots;


    public bool hasKey;
    public bool hasBook;
    public bool hasPhone;
    public bool hasComputer;
    public bool hasPassport;

    //public bool level1End;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
        //level1End = false;
        //gameOverPanel.SetActive(false);

    }

    public void GetScore()
    {
        score += 1;
        SetText();
        if (score == 5)
        {
            LevelEnd();
        }
        //AddImage();
    }


    // Update is called once per frame
    public void SetText()
    {
        scoretext.text = "Elements: " + score.ToString();
    }

    //public void AddImage()
    //{
    //    //Instantiate(scoreElement1, createPoint, Quaternion.identity, GameObject.Find("Canvas").transform);

    //    GameObject temp = Instantiate(scoreElement1, slots[0].transform.position, Quaternion.identity);
    //    temp.transform.SetParent(canvas.transform);
    //    Debug.Log("Key Add");
    //}

    public void AddElement1()
    {
        //print("TESTIN");
        element1.SetActive(true);
        Destroy(inGameElements[0]);
        GetScore();
    }
        
    public void AddElement2()
    {
        element2.SetActive(true);
        Destroy(inGameElements[1]);
        GetScore();
    }
    public void AddElement3()
    {
        element3.SetActive(true);
        Destroy(inGameElements[2]);
        GetScore();
    }
    public void AddElement4()
    {
        element4.SetActive(true);
        Destroy(inGameElements[3]);
        GetScore();
    }
    public void AddElement5()
    {
        element5.SetActive(true);
        Destroy(inGameElements[4]);
        GetScore();
    }

    void LevelEnd()
    {
        
      GameObject.Find("Canvas").transform.Find("GameEndPanel").gameObject.SetActive(true);
      print("LevelEnd");

    }
}
