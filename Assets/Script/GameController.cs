using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class GameController : MonoBehaviour
{
    public TMP_Text Daytext;
    public TMP_Text scoretext;
    public int score = 0;
    public Vector2 createPoint;

    public GameObject scoreElement1;
    public GameObject scoreElement2;
    public GameObject scoreElement3;
    public GameObject scoreElement4;
    public GameObject scoreElement5;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
        
    }

    public void GetScore()
    {
        score += 1;
        SetText();
        AddImage();
    }


    // Update is called once per frame
    public void SetText()
    {
        scoretext.text = "Elements: " + score.ToString();
    }

    public void AddImage()
    {
        //Instantiate(scoreElement1, createPoint, Quaternion.identity, GameObject.Find("Canvas").transform);

        GameObject temp = Instantiate(scoreElement1, this.transform.position, Quaternion.identity);
        temp.transform.SetParent(this.transform);
        Debug.Log("Key Add");
    }
}
