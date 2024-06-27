using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraBlur1 : MonoBehaviour
{
    private PostProcessVolume ppVolume;

    private void Awake()
    {
        ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
       //ppVolume.weight = 0f;
        
    }

    void Start()
    {
    }

  
    void Update()
    {
        if (EndingVideo.over5 == true)
        {
            //ppVolume.enabled = !ppVolume.enabled;
            ppVolume.weight = 0.8f;
            Debug.Log("674458654646");

        }
        else
        {
            if (EndingVideo.over5 == false)
                ppVolume.weight = 0f;
            //Debug.Log("lpapapapap");
        }

    }
}
