using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoFill : MonoBehaviour
{
    public GameObject photoImage;
    public Sprite photoReplaceImage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            FillPhoto();
        }
        else
            return;
    }

    void FillPhoto()
    {
        photoImage.GetComponent<Image>().sprite = photoReplaceImage;
        
    }
}
