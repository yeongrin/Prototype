using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManFaceChange : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite newSprite;
  
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
            Debug.Log("fjfjdsfjjfds");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }

   void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
    }
}
