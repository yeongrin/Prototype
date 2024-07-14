using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManFaceChange : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite newSprite;
    public Sprite newSprite2;
    public Sprite smileSprite;
    public float fliesStayOnFace;
    public float maxTime;

    void Start()
    {

    }

    void Update()
    {
       
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            StartCoroutine("StayOnFace");

        }
    }

    IEnumerable StayOnFace()
    {
        fliesStayOnFace += Time.deltaTime;
        if(fliesStayOnFace >= maxTime)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite2;
        }
        yield return null;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
            fliesStayOnFace = 0;
        }
    }
}
