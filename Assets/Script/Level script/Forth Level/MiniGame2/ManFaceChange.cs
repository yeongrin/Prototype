using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManFaceChange : MonoBehaviour
{
    //public Sprite originalSprite;
    //public Sprite newSprite;
    //public Sprite newSprite2;
    //ublic float fliesStayOnFace;
    // public float maxTime;

    public Animator ani;

    void Start()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
        //ani = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void HitLin()
    {
            ani.SetTrigger("Swat2");
            //StartCoroutine("StayOnFace");
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite2;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            ani.SetTrigger("Swat");
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

            // StartCoroutine("StayOnFace");

        }
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
           
        }
    }
}
