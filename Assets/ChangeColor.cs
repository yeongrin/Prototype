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

    private void Awake()
    {
        CC = () => { ColorBlock(); };
    }

   
    void Start()
    {
        color.a = 1;   
    }

    
    void Update()
    {
        
    }

    public void ColorBlock()
    {
        image.color = Color.white;
    }
}
