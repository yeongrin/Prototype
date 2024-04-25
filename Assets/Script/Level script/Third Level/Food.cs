using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public enum Type
{
    Koala,
    Food,
        Photo

}
public class Food : MonoBehaviour
{
    public Animator ani;
    public Type type;

    public GameObject canvas;

    [Header("Double click")]
    public float DoubleClickSpeed = 0.25f;
    private bool isOneClick = false;
    private double Timer2 = 0;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
            switch(type)
            {
            case Type.Koala:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!isOneClick)
                        {
                          
                            Timer2 = Time.time;
                            isOneClick = true;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "elements" && hit.collider != null)
                            {
                                ani.SetTrigger("Pet");
                               

                            }
                        }
                        else
                        {
                           
                            Timer2 = Time.time;
                            isOneClick = false;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "elements" && hit.collider != null)
                            {

                                ani.SetTrigger("Pet2");


                            }
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
                                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                                if (hit.transform.gameObject.tag == "elements2" && hit.collider != null)
                                {
                                ani.SetTrigger("Eating");
                              

                                }
                            }
                            else
                            {
                               
                                Timer2 = Time.time;
                                isOneClick = false;
                                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                                if (hit.transform.gameObject.tag == "elements2" && hit.collider != null)
                                {

                                ani.SetTrigger("Eating2");
                               
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
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "elements3" && hit.collider != null)
                            {
                                ani.SetTrigger("Shot");
                                Debug.Log("Shot");

                            }
                        }
                        else
                        {
                            
                            Timer2 = Time.time;
                            isOneClick = false;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "elements3" && hit.collider != null)
                            {

                                ani.SetTrigger("Shot2");

                            }
                        }

                    }
                } 
                break;

            }
       
        
    }
}
