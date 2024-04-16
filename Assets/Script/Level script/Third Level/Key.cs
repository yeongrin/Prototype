using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Animator ani;
    private Transform Button;
    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("Object1").transform;

        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void StartAnimation()
    {

    }
}
