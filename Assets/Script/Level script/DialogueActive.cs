using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActive : MonoBehaviour
{
    public bool logueStart;

    void Start()
    {

        logueStart = false;

    }

    
    public void Update()
    {  
       GameObject vid = GameObject.Find("VideoScene1"); //Find video object

        if (vid == false)
        {  
            GameObject dial = GameObject.Find("Canvas").transform.Find("Dialogue").gameObject; //Find dialogue canvas
            logueStart = true;
            if(logueStart == true)
            {
              dial.SetActive(true);
            }
        }
      

        //When the vid is destroyed, SetActive the dial.
        //"LogueStart = true" is the condition that the dial is set active..Maybe..?

    }
}
