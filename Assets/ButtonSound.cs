using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip sound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sound = AudioSourceOfLevel1.instance.arraudio[3];
        audioSource.clip = sound;
    }
    void Start()
    {
        
    }

   public void InputButtonClickSound()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit.collider != null)
            {
                return;
            }
            if(hit.transform.gameObject.tag == "Button")
            {
                audioSource.Play();
            }

        }
    }
}
