using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ParkingCar
{
    Crash,
    Perfect
}

public class Parking : MonoBehaviour
{
    public ParkingCar parkingcar;

    Animator animator;
    Animator animator2;
    public GameObject button;
    public TMP_Text buttonText;

    public float DoubleClickSpeed = 0.25f;
    public float ThirdClickSpeed = 0.5f;
    private bool isOneClick = false;
    private bool isSecClick = false;
    private double Timer2 = 0;
    private double Timer3 = 0;

    public GameObject crash;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator2 = button.GetComponent<Animator>();

    }

    void Update()
    {
        switch (parkingcar)
        {
            case ParkingCar. Crash:
                {

                    CarGetAccident();
                }
            break;

            case ParkingCar. Perfect:
                {
                    CarParkingSmooth();
                }
            break;
        }
  
    }

    public void CarGetAccident()
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

                    animator.SetTrigger("Park");

                buttonText.text = "A little more....";
 
            }
            else if (isOneClick & !isSecClick)
            {

                Timer2 = Time.time;
                Timer3 = Time.time;
                isOneClick = false;
                isSecClick = true;
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                    animator.SetTrigger("Park2");

                buttonText.text = "A little more...more..";

            }
            else
            {
                Timer2 = Time.time;
                Timer3 = Time.time;
                isOneClick = false;
                isSecClick = false;

                animator.SetTrigger("Park3");
                buttonText.text = "CRASH!!!!!";
                Bonk();
            }
        }
    }

    public void CarParkingSmooth()
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

    public void Bonk()
    {
        animator2.SetTrigger("Crash");
        crash.gameObject.SetActive(true);
        MiniGame3Manager.endVideoStart = true;
       
    }

    public void PerfectParking()
    {
        crash.gameObject.SetActive(true);
    }

}
