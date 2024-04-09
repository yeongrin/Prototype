using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public GameObject human;
    string obName;
    SpriteRenderer _render;
    
    void Start()
    {
        _render = gameObject.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
           

            if (hit.transform.gameObject.tag == "Object1" && hit.collider != null)
            { obName = hit.transform.name;

                if (obName == "People")
                {
                  
                GameObject click_obj = hit.transform.gameObject;
                _render.color = Color.black;
                Debug.Log(click_obj.name);
                StartCoroutine("FadeOut");
                }
             
                              
            }
            else if (obName == "People(1)")
            {
                GameObject click_obj = hit.transform.gameObject;
                _render.color = Color.black;
                Debug.Log(click_obj.name);
            }
              
        }
    }

    IEnumerator FadeOut()
    {
        int i = 10;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = _render.material.color;
            c.a = f;
            _render.material.color = c;
            yield return new WaitForSeconds(0.05f);
            Destroy(gameObject, 1);
        }
    }
}
