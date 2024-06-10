using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public enum Type
{
    Koala,
    Food,
    Photo,
    None

}

public class Travel : MonoBehaviour
{
    //public GameController3 gameCon3;

    public Animator ani;
    public Type type;

    [Header("Double click")]
    public float DoubleClickSpeed = 0.25f;
    private bool isOneClick = false;
    private double Timer2;

    [Header("CountDown")]
    public float StartTime;
    public float Timer;

    void Start()
    {
        StartTime = 5f;
        Timer = 5f;
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        switch (type)
        {

            case Type.None:
                {
                   
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hit.transform.gameObject.tag == "elements" && hit.collider != null)
                        {
                            //ScoreLevel();
                        }
                        else if (hit.transform.gameObject.tag == "elements2" && hit.collider != null)
                        {
                            //ScoreLevel();
                        }
                        else if (hit.transform.gameObject.tag == "elements3" && hit.collider != null)
                        {
                            //ScoreLevel();
                        }
                    }

                }
                break;

            case Type.Koala:
                {
                    if (Timer == 0)
                    {
                        Debug.Log("Byebye");
                        Destroy(this.gameObject);
                        TimerReset();
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!isOneClick)
                        {

                            Timer2 = Time.time;
                            isOneClick = true;
                           
                            if (hit.transform.gameObject.tag == "elements" && hit.collider != null)
                            {
                                ani.SetTrigger("Pet");
                                Debug.Log("35436334");
                                GameController3.gameCon3();
                                Invoke("Destroy", 2);
                            }
                        }
                        /*else
                        {
                           
                            Timer2 = Time.time;
                            isOneClick = false;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "elements" && hit.collider != null)
                            {

                                ani.SetTrigger("Pet2");
                               // ScoreLevel();
                                gameObject.GetComponent<GameController3>().enabled = false;
                          
                                

                            }
                        }*/
                    }
                }
                break;

            case Type.Food:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!isOneClick)
                        {

                            Timer2 = Time.time;
                            isOneClick = true;
                          
                            if (hit.transform.gameObject.tag == "elements2" && hit.collider != null)
                            {
                                ani.SetTrigger("Eating");
                                Debug.Log("67908998");
                            }
                        }
                       else
                       {

                            Timer2 = Time.time;
                            isOneClick = false;
                           

                            if (hit.transform.gameObject.tag == "elements2" && hit.collider != null)
                            {

                                ani.SetTrigger("Eating2");
                                GameController3.gameCon3();
                                //gameObject.GetComponent<GameController3>().enabled = false;
                                Invoke("Destroy", 2);

                            }

                       }



                    }
                }
                break;

            case Type.Photo:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!isOneClick)
                        {

                            Timer2 = Time.time;
                            isOneClick = true;

                            if (hit.transform.gameObject.tag == "elements3" && hit.collider != null)
                            {
                                ani.SetTrigger("Shot");
                                Debug.Log("Shot");
                                GameController3.gameCon3();
                                Invoke("Destroy", 2);
                                //ScoreLevel();
                            }
                        }
                       /*else
                        {

                            Timer2 = Time.time;
                            isOneClick = false;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "elements3" && hit.collider != null)
                            {

                                ani.SetTrigger("Shot2");
                                //ScoreLevel();
                                gameObject.GetComponent<GameController3>().enabled = false;

                            }
                        }*/

                    }
                }
                break;

        }
    }

    void TimerReset()
    {
        StartTime = Timer;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
