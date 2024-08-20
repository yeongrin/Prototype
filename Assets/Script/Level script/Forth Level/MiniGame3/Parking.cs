using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;

public enum ParkingCar
{
    Crash,
    Perfect
}

public class Parking : MonoBehaviour
{
    public ParkingCar parkingcar;

    public Animator animator;
    public Animator animator2;

    public float DoubleClickSpeed = 0.25f;
    public float ThirdClickSpeed = 0.5f;
    private bool isOneClick = false;
    private bool isSecClick = false;
    private double Timer2 = 0;
    private double Timer3 = 0;

    public AudioClip[] audioClip;
    public AudioClip currentAudioClip;
    public AudioSource audioSource;

    public GameObject crash;
    public int clickCount;

    void Start()
    {
        clickCount = 0;
    }

    public void CarGetAccident()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        //    if (hit.transform.gameObject.tag == "Button" && hit.collider != null)
        //    {
        //        if (!isOneClick & !isSecClick)
        //        {

        //            Timer2 = Time.time;
        //            Timer3 = Time.time;
        //            isOneClick = true;
        //            isSecClick = false;

        //            animator.SetTrigger("Park");
        //            animator2.SetTrigger("LittleMore");


        //        }
        //        else if (isOneClick & !isSecClick)
        //        {

        //            Timer2 = Time.time;
        //            Timer3 = Time.time;
        //            isOneClick = false;
        //            isSecClick = true;

        //            animator.SetTrigger("Park2");
        //            animator2.SetTrigger("LittleMoreMore");

        //        }
        //        else
        //        {
        //            Timer2 = Time.time;
        //            Timer3 = Time.time;
        //            isOneClick = false;
        //            isSecClick = false;

        //            animator.SetTrigger("Park3");

        //            Bonk();
        //        }
        //    }
        //}

        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (clickCount == 0)
        {
            animator.SetTrigger("Park");
            animator2.SetTrigger("LittleMore");

            currentAudioClip = audioClip[0];
            audioSource.Play();

            clickCount = 1;
            
        }
            else if (clickCount == 1)
            {
                animator.SetTrigger("Park2");
                animator2.SetTrigger("LittleMoreMore");

            currentAudioClip = audioClip[1];
            audioSource.Play();

            clickCount = 2;
            }
        else
        {
            if (clickCount == 2)
            {
                animator.SetTrigger("Park3");
                Bonk();

            }
        }
        
    }

    public void CarParkingSmooth()
    {

        if (clickCount == 0)
        {
            currentAudioClip = audioClip[0];
            animator.SetTrigger("perfect");
        }
         
    }

    public void Bonk()
    {
        animator2.SetTrigger("Crash");
        crash.gameObject.SetActive(true);

        currentAudioClip = audioClip[1];
        audioSource.Play();

        MiniGame3Manager.endVideoStart = true;
       
    }

    public void PerfectParking()
    {
        currentAudioClip = audioClip[1];
        crash.gameObject.SetActive(true);
        
    }

}
