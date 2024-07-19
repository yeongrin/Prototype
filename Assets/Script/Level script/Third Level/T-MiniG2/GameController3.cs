using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController3 : MonoBehaviour
{
    public static Action gameCon3;
    public GameObject canvas;
    public GameObject flashObject;
    
    public float flashSpeed;

    public Slider slider;
    //private int maxScore = 10;
    public int score;

    public void Awake()
    {
        gameCon3 = () =>
        {
            ScoreLevel();
            ScoreSlider();
            
        };
        

    }

    void Start()
    {
        slider.value = 0;
        //ani = GetComponent<Animator>();
      
        ScoreSlider();
    }

    public void ScoreLevel()
    {
        score += 1;
        ScoreSlider();

        if (score == 10)
        {
            //GameObject.Find("Game").transform.Find("Scene2").gameObject.SetActive(true);
            //GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
        }
    }
    void Update()
    {
        
        
    }

    public void ScoreSlider()
    {
        slider.value = score;
    }

    public IEnumerator CameraFlash()
    {
        flashObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        flashObject.SetActive(false);
        
        
    }
}
