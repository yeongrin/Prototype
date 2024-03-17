using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject bridge;
    public GameObject startPoint2;
    public GameObject endPoint2;

    public Vector2 startPost2;
    public Vector2 targetPost2;

    public float speed;

    public float startTime2;
    public float duration2;
    //Don't write the code same with other name. 

    public bool test;
    public bool test2;

    [Header("Double click")]
    public float DoubleClickSpeed = 0.25f;
    private bool isOneClick = false;
    private double Timer2 = 0;

    void Start()
    {
        startTime2 = Time.time;

        startPoint2.transform.position = transform.position;
    }

    
    void Update()
    {

        /*if (isOneClick && (Time.time - Timer) > DoubleClickSpeed)
     {
         Debug.Log("One clicked");
         isOneClick = false;
     }*/

        if (Input.GetMouseButtonDown(0))
        {

            if (!isOneClick)
            {
                print("firstone");
                Timer2 = Time.time;
                isOneClick = true;
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                {
                    float progress = (Time.deltaTime - startTime2) / duration2;
                    progress = Mathf.Clamp(progress, 0, 1);

                    Vector2 startPost2 = startPoint2.transform.position;
                    Vector2 targetPost2 = endPoint2.transform.position;

                    test = true;
                    test2 = false;

                }
            }else
            {
                print("secondone");
                Timer2 = Time.time;
                isOneClick = false;
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                {
                    float progress = (Time.deltaTime - startTime2) / duration2;
                    progress = Mathf.Clamp(progress, 0, 1);

                    Vector2 startPost = startPoint2.transform.position;
                    Vector2 targetPost = endPoint2.transform.position;
                    //Vector2 originpo = (startPost + (targetPost - startPost) * progress + new Vector2(-1f, 0) * speed);
                    //transform.position = originpo;
                    //transform.position = endPoint.transform.position;
                    test2 = true;
                    test = false;
                }
            }
        }

        if (test == true && test2 == false)
        {
            //print("jjgjgejge");
            transform.position = Vector3.Lerp(transform.position, endPoint2.transform.position, speed);
        }

        if (test2 == true && test == false)
        {
            //print("jjgjgejge");
            transform.position = Vector3.Lerp(transform.position, startPoint2.transform.position, speed);
        }
    }
}
