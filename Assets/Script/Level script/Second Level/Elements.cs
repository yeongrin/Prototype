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

    float curC;
    float ColorCurve = -0.3f;

    void Start()
    {
        //_render = gameObject.GetComponent<SpriteRenderer>();
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
                            
                            StartCoroutine("FadeOut");
                            Debug.Log("Color");

                        }
                    }
            break;
            }
            


        }
    
    }

    IEnumerator FadeOut()
    {
        for (curC = 0; curC <= 1; curC += Time.deltaTime)
        {
            if (curC >= 1)
            {
                G += curC * ColorCurve;
                B += curC * ColorCurve;
                R += curC * ColorCurve;
                Debug.Log("Plus");
            }
            yield return new WaitForSeconds(0.1f);
            ElementColor.material.color = new Color(R / 255f, G / 255f, B / 255f);
        }

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
}
