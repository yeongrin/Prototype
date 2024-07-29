using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParkingCar
{
    Crash,
    Perfect
}

public class Parking : MonoBehaviour
{
    public ParkingCar parkingcar;

    public GameObject car;
    Animator animator;

    public float DoubleClickSpeed = 0.25f;
    public float ThirdClickSpeed = 0.5f;
    private bool isOneClick = false;
    private bool isSecClick = false;
    private double Timer2 = 0;
    private double Timer3 = 0;

    public GameObject crash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (parkingcar)
        {
            case ParkingCar. Crash:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!isOneClick & !isSecClick)
                        {

                            Timer2 = Time.time;
                            Timer3 = Time.time;
                            isOneClick = true;
                            isSecClick = false;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                            {
                                animator.SetTrigger("Park");

                            }
                        }
                        else if (isOneClick & !isSecClick)
                        {

                            Timer2 = Time.time;
                            Timer3 = Time.time;
                            isOneClick = false;
                            isSecClick = true;
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                            if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                            {

                                animator.SetTrigger("Park2");


                            }
                        }
                        else
                        {
                            Timer2 = Time.time;
                            Timer3 = Time.time;
                            isOneClick = false;
                            isSecClick = false;

                            animator.SetTrigger("Park3");
                            Bonk();
                        }
                    }
                }
            break;

            case ParkingCar. Perfect:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                       
                        if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                        {
                            animator.SetTrigger("perfect");
                            
                        }
                    }
                }
            break;
        }
  
    }

    public void Bonk()
    {
        crash.gameObject.SetActive(true);
        MiniGame3Manager.endVideoStart = true;
       
    }

    public void PerfectParking()
    {
        crash.gameObject.SetActive(true);
    }

}
