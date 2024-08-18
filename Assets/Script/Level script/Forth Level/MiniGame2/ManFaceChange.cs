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

    [Header("Audio")]
    public AudioClip[] source;
    AudioSource audioSource;

    void Start()
    {
        //this.processingObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
        //ani = GetComponent<Animator>();

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = source[Random.Range(0, 2)];
    }

    void Update()
    {

    }

    public void HitLin()
    {
        audioSource.Play();
        ani.SetTrigger("Swat2");
        //StartCoroutine("StayOnFace");
        //this.processingObject.GetComponent<SpriteRenderer>().sprite = newSprite2;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            ani.SetTrigger("Swat");
            //this.processingObject.GetComponent<SpriteRenderer>().sprite = newSprite;

            // StartCoroutine("StayOnFace");

        }
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            //this.processingObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
           
        }
    }
}
