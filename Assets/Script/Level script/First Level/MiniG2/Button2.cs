using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    private Transform Button;

    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("Object2").transform;
       
    }


    public void DestroyObj()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy2"));
    }
}
