using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PhotoController : MonoBehaviour
{
    public TMP_Text score_Text;
    public int score = 0;

    public GameObject canvas;
    public GameObject endingCanvas;

    public GameObject photo1;
    public GameObject photo2;
    public GameObject photo3;
    public GameObject photo4;
    public GameObject photo5;

    void Start()
    {
        SetText2();
    }

    public void GetScore()
    {
        score += 1;
        SetText2();
        if (score == 5)
        {
            LevelEnd2();
        }
    }

    void Update()
    {
        
    }

    public void SetText2()
    {
        score_Text.text = "Photo:" + score.ToString();
    }

    void LevelEnd2()
    {

        GameObject.Find("Scene3").transform.Find("EndingPanel").gameObject.SetActive(true);
        print("LevelEnd");
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Photo1")
        {
            GetScore();
        }
    }
}
