using System;
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
    Shiny,
    None

}

public class Travel : MonoBehaviour
{
    //public GameController3 gameCon3;

    
    public Animator ani;
    public Type type;
    SpawnPhoto _sp;
    GameController3 _gm3;
    PhotoLoader _pl;
    SpawnShinyPhoto _ssp;
    BonusPhoto _bp;

    Camera cam;
    Vector3 MousePosition;

    [Header("Double click")]
    public float DoubleClickSpeed = 0.25f;
    private bool isOneClick = false;
    private double Timer2;
    public bool hasClicked;

    [Header("CountDown")]
    public float StartTime;
    public float Timer;

    public float speed;
    public float shinySpeed;

    

    void Start()
    {
        StartTime = 5f;
        
        if (gameObject.tag == ("elements4"))
        {
            Timer = 10f;
        }
        else
            Timer = 5f;

        ani = GetComponent<Animator>();
        cam = GetComponent<Camera>();
        _sp = GameObject.FindObjectOfType<SpawnPhoto>();
        _gm3 = FindObjectOfType<GameController3>();
        _pl = FindObjectOfType<PhotoLoader>();
        _ssp = FindObjectOfType<SpawnShinyPhoto>();
        _bp = FindObjectOfType<BonusPhoto>();

        hasClicked = false;
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 0f);
        //if(hit.collider != null) print(hit.collider.name);

        if (Timer <= 0)
        {
            Debug.Log("Byebye");
            Destroy(this.gameObject);
            TimerReset();
            //When timer reaches zero the item will disappear.
        }

        switch (type)
        {

            case Type.Koala:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                       
                           
                            if (hit.transform.gameObject.tag == "elements" && hit.collider != null && hasClicked == false)
                            {
                                hasClicked = true;
                                ani.SetTrigger("Pet");
                                Debug.Log("35436334");
                                Invoke("Destroy", 2);
                            }
                        
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
                                //gameObject.GetComponent<GameController3>().enabled = false;
                                Invoke("Destroy", 2);

                            }

                       }



                    }
                }
                break;

            case Type.Photo:
                {
                    
                    this.gameObject.transform.position = Vector2.MoveTowards(this.transform.position, _sp.target.position, speed * Time.deltaTime);
                    

                    if (Input.GetMouseButtonDown(0))
                    {
                        print("Clicking");
                 
                            if (hit.transform.gameObject.tag == "elements3" && hit.collider != null && hasClicked == false)
                            {
                                hasClicked = true;
                                ani.SetTrigger("Shot");
                                Debug.Log("Shot");
                                StartCoroutine(_gm3.CameraFlash());
                                Invoke("Destroy", 0.4f);
                                _pl.TakePhoto();
                            }

                    }
                }
                break;

            case Type.Shiny:
                {
                    
                    this.gameObject.transform.position = Vector2.MoveTowards(this.transform.position, _ssp.target.transform.position, shinySpeed * Time.deltaTime);

                    if (Input.GetMouseButtonDown(0))
                    {
                        print("Clicking");

                        if (hit.transform.gameObject.tag == "elements4" && hit.collider != null && hasClicked == false)
                        {
                            hasClicked = true;
                            Debug.Log("Shot");
                            Destroy(this.gameObject, 0.5f);
                            StartCoroutine(_gm3.CameraFlash());
                            //_bp.hasBonusPhoto = true;
                            _ssp.hasClicked = true;
                        }

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
