using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button4 : MonoBehaviour
{
    private Transform Button;

    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("Object4").transform;
    }


    public void DestroyObj()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy4"));
    }
}
