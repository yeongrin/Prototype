using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public enum Type
{
    Koala,
    Food

}
public class Food : MonoBehaviour
{
    public Animator ani;
    public Type type;

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
                                //print("firstone");
                                Timer2 = Time.time;
                                isOneClick = true;
                                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                                if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                                {
                                ani.SetBool("Eating", true);

                                }
                            }
                            else
                            {
                                //print("secondone");
                                Timer2 = Time.time;
                                isOneClick = false;
                                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                                if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                                {

                                ani.SetBool("Eating2", true);

                            }
                            }



                        }
                    }
                    break;
            }
        
    }
}
