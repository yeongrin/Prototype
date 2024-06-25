using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject canvas;
    GameObject SplashObj;
    Image image;

    private bool checkbool = false;
   
    void Awake()
    {
        SplashObj = this.gameObject;
        image = SplashObj.GetComponent<Image>();
    }

    void Update()
    {
        StartCoroutine("Delay");

        //When the fade out coroutine stops, start the main game. 
        if(checkbool)
        {
            //canvas.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine("MainSplash");
    }

    IEnumerator MainSplash()
    {
        
        Color color = image.color;

        for(int i = 150; i>=0; i--)
        {
            
            color.a -= Time.deltaTime * 0.01f;

            image.color = color;

            if (image.color.a <= 0)
            {
                checkbool = true;
            }
        }
        yield return null;
    }
}
