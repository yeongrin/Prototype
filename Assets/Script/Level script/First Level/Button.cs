using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
    SpriteRenderer _render;

    private Color orgColor;
    private bool check;

    public void Awake()
    {
        check = false;
        orgColor = new Color(1f, 1f, 1f, 1f);
    }

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
            {
                GameObject click_button = hit.transform.gameObject;
                //_render.color = Color.black;

                

                if(!check)
                {
                    StartCoroutine("EButton", button);
                    check = true;

                }
                else
                {
                    StopCoroutine("EButton");
                    button.GetComponent<SpriteRenderer>().color = orgColor;
                    check = false;
                }
                
            }
        }


    }

    public IEnumerator EButton()
    {

        Color tempColor = orgColor;

        gameObject.GetComponent<SpriteRenderer>().color = tempColor;
        

        while(true)
        {
            while(gameObject.GetComponent<SpriteRenderer>().color.a > 0f)
            {
                tempColor.a -= 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = tempColor;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.1f);
            while (gameObject.GetComponent<SpriteRenderer>().color.a < 1f)
            {
                tempColor.a += 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = tempColor;
                yield return new WaitForSeconds(0.01f);
            }
            break;
            
            
        }
        
    }

}
