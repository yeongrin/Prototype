using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    public GameObject gameObject;
    public PostProcessVolume m_Volume;
    Vignette m_Vignette;
    float process;

    void Start()
    {
        //m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        //m_Vignette.enabled.Override(true);
        //m_Vignette.intensity.Override(1f);
        //m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);

        m_Vignette = gameObject.GetComponent<Vignette>();
        m_Vignette.intensity.value = 0f;

        StartCoroutine("TurnRedLight");
    }

    void Update()
    {
       
    }

    IEnumerable TurnRedLight()
    {
        Debug.Log("start");

        m_Vignette.intensity.value = process;

        while (true)
        {
            while (process < 1f)
            {
                process += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.5f);
            while (process > 1f)
            {
                process -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}
