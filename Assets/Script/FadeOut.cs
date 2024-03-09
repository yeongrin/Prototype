using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    GameObject SplashObj2;
    Image image2;

    private bool checkbool = false;
    // Start is called before the first frame update
    void Awake()
    {
        SplashObj2 = this.gameObject;
        image2 = SplashObj2.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("MainSplash2");
        if (checkbool)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator MainSplash2()
    {
        Color color = image2.color;

        for (int i = 100; i >= 0; i--)
        {
            color.a += Time.deltaTime * 0.01f;

            image2.color = color;

            if (image2.color.a <= 0)
            {
                checkbool = true;
            }
        }
        yield return null;
    }
}