using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{
    public Animator animator;
    private Transform Button1;

    // Start is called before the first frame update
    void Start()
    {
        Button1 = GameObject.FindGameObjectWithTag("Object1").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
