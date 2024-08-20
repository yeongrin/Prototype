using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController3 : MonoBehaviour
{
    public GameObject flashObject;
    public Sprite[] newImage;
    public int imageInt;
    Image flashImage;
    public bool flash;
    public Animator ani;

    private void Start()
    {
        flash = false;
        imageInt = 0;
        flashImage = flashObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (flash == true)
        {
            StartCoroutine(CameraFlash());
        }
        else
            StopCoroutine(CameraFlash());
    }
    public IEnumerator CameraFlash()
    {
        Color color = flashImage.color;
        
        flashObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        
        for (int i = 150; i>=0; i--)
        {
            Debug.Log("camera flash");
            flashImage.color = color;
            color.a -= Time.deltaTime * 1f;
            

            if(color.a <= 0)
            {
                
                flash = false;
                flashObject.SetActive(false);

                StopCoroutine(CameraFlash());
            }
            color.a = 255;

        }

    }
    public void startAnimationFlash()
    {
        ani.SetTrigger("FlashCamera");
        Debug.Log("TakePhoto");
    }
}
