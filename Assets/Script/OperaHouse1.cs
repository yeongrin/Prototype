using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public enum MovingType1
{
    Moving1,
        Moving2
}

public class OperaHouse1 : MonoBehaviour
{
    public MovingType1 movingType1;

    public GameObject operaHouse;
    public GameObject startPoint;
    public GameObject endPoint;

    public GameObject startPoint2;
    public GameObject endPoint2;

    public Vector2 startPost;
    public Vector2 targetPost;

    public Vector2 startPost2;
    public Vector2 targetPost2;

    public float speed;

    public float startTime;
    public float duration;


    public bool test;
    public bool test2;

    [Header("Double click")]
    public float DoubleClickSpeed = 0.25f;
    private bool isOneClick = false;
    private double Timer = 0;

    void Start()
    {
        startTime = Time.time;

        startPoint.transform.position = transform.position;
    }


    void Update()
    {

        /*if (isOneClick && (Time.time - Timer) > DoubleClickSpeed)
        {
            Debug.Log("One clicked");
            isOneClick = false;
        }*/

        switch (movingType1)
        {
            case MovingType1.Moving1:
                {
                    if (Input.GetMouseButtonDown(0))
                    {

                        if (!isOneClick)
                        {
                            //print("firstone");
                            Timer = Time.time;
                            isOneClick = true;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "Object2" && hit.collider != null)
                            {
                                float progress = (Time.deltaTime - startTime) / duration;
                                progress = Mathf.Clamp(progress, 0, 1);

                                Vector2 startPost = startPoint.transform.position;
                                Vector2 targetPost = endPoint.transform.position;
                                //Vector2 originpo = (startPost + (targetPost - startPost) * progress + new Vector2(-1f, 0) * speed);
                                //transform.position = originpo;
                                //transform.position = endPoint.transform.position;
                                test = true;
                                test2 = false;

                            }
                        }
                        else
                        {
                            //print("secondone");
                            Timer = Time.time;
                            isOneClick = false;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "Object2" && hit.collider != null)
                            {
                                float progress = (Time.deltaTime - startTime) / duration;
                                progress = Mathf.Clamp(progress, 0, 1);

                                Vector2 startPost = startPoint.transform.position;
                                Vector2 targetPost = endPoint.transform.position;
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
                        transform.position = Vector3.Lerp(transform.position, endPoint.transform.position, speed);
                    }

                    if (test2 == true && test == false)
                    {
                        //print("jjgjgejge");
                        transform.position = Vector3.Lerp(transform.position, startPoint.transform.position, speed);
                    }
                }
                break;
            case MovingType1.Moving2:
                {
                    if (Input.GetMouseButtonDown(0))
                    {

                        if (!isOneClick)
                        {
                           
                            Timer = Time.time;
                            isOneClick = true;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.name == "People(3)" && hit.collider != null)
                            {
                                float progress = (Time.deltaTime - startTime) / duration;
                                progress = Mathf.Clamp(progress, 0, 1);

                                Vector2 startPost2 = startPoint2.transform.position;
                                Vector2 targetPost2 = endPoint2.transform.position;
                                
                                test = true;
                                test2 = false;

                            }
                        }
                        else
                        {
                            
                            Timer = Time.time;
                            isOneClick = false;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.name == "People(3)" && hit.collider != null)
                            {
                                float progress = (Time.deltaTime - startTime) / duration;
                                progress = Mathf.Clamp(progress, 0, 1);

                                Vector2 startPost2 = startPoint2.transform.position;
                                Vector2 targetPost2 = endPoint2.transform.position;
                               
                                test2 = true;
                                test = false;
                            }
                        }

                    }


                    if (test == true && test2 == false)
                    {
                        
                        transform.position = Vector3.Lerp(transform.position, endPoint2.transform.position, speed);
                    }

                    if (test2 == true && test == false)
                    {
                        
                        transform.position = Vector3.Lerp(transform.position, startPoint2.transform.position, speed);
                    }
                }
                break;
        }

       
    }
}

       