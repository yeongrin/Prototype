using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Wrong()
    {
        ani.SetTrigger("wrong");
    }
}
