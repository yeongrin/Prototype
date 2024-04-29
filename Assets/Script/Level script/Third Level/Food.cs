using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public enum Type
{
    Koala,
    Food,
        Photo,
    None

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

    public Slider slider;
    private int maxScore = 6;
    public int score;
    

    void Start()
    {
        slider.value = 0;
        ani = GetComponent<Animator>();

        ScoreSlider();
    }

    void Update()
    {
       
            switch(type)
            {
            case Type.None:
                break;

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
                                ScoreLevel();

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
                                ScoreLevel();
                                

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
                                ScoreLevel();
                                
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
                                ScoreLevel();
                                
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
                                ScoreLevel();
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
                                ScoreLevel();
                               
                            }
                        }

                    }
                } 
                break;

            }
       
        
    }

    void ScoreLevel()
    {
        score += 1;
        ScoreSlider();

        if (score == 6)
        {
            GameObject.Find("Game").transform.Find("Scene2").gameObject.SetActive(true);
            GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
        }
    }
    


    void ScoreSlider()
    {
        slider.value = score;
    }
}
