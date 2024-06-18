using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System;

/*public enum Type
{
    Koala,
    Food,
    Photo,
    None

}*/
public class GameController3 : MonoBehaviour
{
    public static Action gameCon3;

    //public Animator ani;
    //public Type type;

    public GameObject canvas;

    /*[Header("Double click")]
    public float DoubleClickSpeed = 0.25f;
    private bool isOneClick = false;
    private double MiniGame2 = 0;*/

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
}
