using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using static Unity.Burst.Intrinsics.X86.Avx;

public class PostProcessingController : MonoBehaviour
{
   
    [SerializeField] private PostProcessVolume m_Volume;
    public GameObject processingObject;
    //public Vignette m_Vignette;
    float process;
    bool reverse;

    void Start()
    {
        m_Volume = gameObject.GetComponent<PostProcessVolume>();
        
        //Instance the postProcessing
        //m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        //m_Vignette.enabled.Override(true);
        //m_Vignette.intensity.Override(0f);
        //m_Volume = PostProcessManager.instance.QuickVolume(processingObject.layer, 0f, m_Vignette);

        //m_Volume = gameObject.GetComponent<PostProcessVolume>();
        //m_Volume.weight = process;
        //m_Volume.weight = 1f;

    }

    void Update()
    {
        //if (m_Volume.weight < 1f && !reverse)
        //{
        //    m_Volume.weight += 0.01f;
        //}
        //else if (m_Volume.weight > 1f && reverse)
        //{
        //    m_Volume.weight -= 0.01f;
        //}

        //if (m_Volume.weight == 1)
        //    reverse = true;
        //else if (m_Volume.weight == 0)
        //    reverse = false;
       
    }

    //IEnumerator TurnRedLight()
    //{
    //    m_Volume.weight = process;
    //    m_Volume = gameObject.GetComponent<PostProcessVolume>();

    //    while (true)
    //    {
    //        while (process > 0f)
    //        {
    //            process -= 0.01f;
    //            yield return new WaitForSeconds(0.05f);
    //        }
    //        yield return new WaitForSeconds(0.5f);
    //        while (process < 1f)
    //        {
    //            process += 0.01f;
    //            yield return new WaitForSeconds(0.05f);
    //        }
    //        yield return new WaitForSeconds(0.5f);

    //    }
    //}

}
