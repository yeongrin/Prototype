using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementsType
{
    one,
    two,
    three,
    four
}

public class Elements : MonoBehaviour
{
    public GameObject elements;
    public ElementsType elementsType;
    //SpriteRenderer _render;

    public Renderer ElementColor;

    float R = 0f;
    float G = 0f;
    float B = 0f;

    public float curC;
    float ColorCurve = -0.3f;

    public float fadein;
    void Start()
    {
        //_render = processingObject.GetComponent<SpriteRenderer>();
        ElementColor = gameObject.GetComponent<Renderer>();
        ElementColor.material.color = new Color(R / 0, G / 0, B / 0);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            switch (elementsType)
            {
            case ElementsType.one:
                {
                        if (hit.transform.gameObject.tag == "elements" && hit.collider != null)
                        {
                            GameObject click_obj = hit.transform.gameObject;
                            //_render.color = Color.white;
                            
                            StartCoroutine("FadeIn1");
                            Debug.Log("Color");

                        }
                    }
            break;
                case ElementsType.two:
                    {
                        if (hit.transform.gameObject.tag == "elements2" && hit.collider != null)
                        {
                            GameObject click_obj = hit.transform.gameObject;
                        
                            StartCoroutine("FadeIn2");
                        }
                    }
                    break;

                case ElementsType.three:
                    {
                        if (hit.transform.gameObject.tag == "elements3" && hit.collider != null)
                        {
                            GameObject click_obj = hit.transform.gameObject;
                           
                            StartCoroutine("FadeIn3");
                        }
                    }
                    break;

                case ElementsType.four:
                    {
                        if(hit.transform.gameObject.tag == "elements4" && hit.collider != null)
                                

                            {
                            GameObject clilck_obj = hit.transform.gameObject;
                            StartCoroutine("FadeIn4");
                            }
                    }
                    break;
            }
            
        }

        ElementColor.material.color = Color.Lerp(Color.black, Color.white, fadein / 255);
    }

    IEnumerator FadeIn1()
    {
        for (curC = 0; curC < 255; curC += 1)
        {
            if (curC >= 1)
            {
                G += curC * ColorCurve;
                B += curC * ColorCurve;
                R += curC * ColorCurve;
               
            }
            
            //ElementColor.material.color = new Color(R / 255f, G / 255f, B / 255f);
            fadein += 1;
            //print(fadein);
            //ElementColor.material.color = Color.Lerp(Color.black, Color.white, fadein);

            yield return new WaitForSeconds(0.001f);
        }
        
        //ElementColor.material.color = Color.Lerp(Color.black, Color.white, 20 * Time.deltaTime);
        //yield return new WaitForSeconds(10.1f);
        /*int i = 0;
        while (i < 10)
        {
            i += 1;
            float f = i / 10.0f;
            Color c = _render.material.color;
            c.a = f;
            _render.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }*/

        //https://simposter.tistory.com/79
    }

    IEnumerator FadeIn2()
    {
        for (curC = 0; curC < 255; curC += 1)
        {
            if (curC >= 1)
            {
                G += curC * ColorCurve;
                B += curC * ColorCurve;
                R += curC * ColorCurve;
              
            }
            fadein += 1;

            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator FadeIn3()
    {
        for (curC = 0; curC < 255; curC += 1)
        {
            if (curC >= 1)
            {
                G += curC * ColorCurve;
                B += curC * ColorCurve;
                R += curC * ColorCurve;

            }
            fadein += 1;

            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator FadeIn4()
    {
        for (curC = 0; curC < 255; curC += 1)
        {
            if (curC >= 1)
            {
                G += curC * ColorCurve;
                B += curC * ColorCurve;
                R += curC * ColorCurve;

            }
            fadein += 1;

            yield return new WaitForSeconds(0.001f);
        }
    }
}
