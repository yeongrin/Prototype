using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeColor : MonoBehaviour
{
    public static Action CC;

    [SerializeField]
    private Image image;
    private Color color;
    PuzzleGame2 _pg2;
    public int photoNumber;

    private void Awake()
    {
        CC = () => { ColorBlock(); };
    }

   
    void Start()
    {
        color.a = 1;
        _pg2 = FindObjectOfType<PuzzleGame2>();
    }

    
    void Update()
    {
        
    }

    public void ColorBlock()
    {
        image.color = Color.white;
    }
}
