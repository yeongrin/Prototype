using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanType
{
    people1, people2
}

public class People : MonoBehaviour
{
    public HumanType humanType;

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


            switch (humanType)
            {
                case HumanType.people1:
                    {
                        if (hit.transform.gameObject.tag == "Object1" && hit.collider != null)
                        {
                            obName = hit.transform.name;

                                GameObject click_obj = hit.transform.gameObject;
                                _render.color = Color.white;
                                Debug.Log(click_obj.name);
                                StartCoroutine("FadeOut");

                        }

                    }
                    break;

                case HumanType.people2:

                    {
                        if (hit.transform.gameObject.name == "People(1)" && hit.collider != null)
                        {

                                GameObject click_obj = hit.transform.gameObject;
                                _render.color = Color.white;
                                Debug.Log(click_obj.name);
                            StartCoroutine("FadeOut");

                        }
                    }
                    break;
             

            }
        } 
           

            //If문으로 오브젝트를 구별해서 레이캐스트를 사용하려 들지 말아라.
            //Switch 구문으로 구별한다.

        
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
