using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    GameObject SplashObj;
    Image image;

    private bool checkbool = false;
    // Start is called before the first frame update
    void Awake()
    {
        SplashObj = this.gameObject;
        image = SplashObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("MainSplash");
        if(checkbool)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator MainSplash()
    {
        Color color = image.color;

        for(int i = 100; i>=0; i--)
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
