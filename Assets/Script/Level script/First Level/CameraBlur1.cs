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
       ppVolume.weight = 0.2f;
        
    }

  
    void Update()
    {
        if (GameManager.overCount == 1)
        {
            //ppVolume.enabled = !ppVolume.enabled;
            ppVolume.weight = 0.3f;

            if(GameManager.overCount == 2)
            {
                ppVolume.weight = 0.4f;

            }
            if(GameManager.overCount == 3)
            {
                ppVolume.weight = 0.5f;
            }
            if(GameManager.overCount == 4)
            {
                ppVolume.weight = 0.6f;
            }
        }
        
        else
        {
            if (GameManager.overCount == 0)
                ppVolume.weight = 0f;
                
        }

    }
}
