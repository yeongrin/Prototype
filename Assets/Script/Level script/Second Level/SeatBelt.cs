using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatBelt : MonoBehaviour
{
    Animator animator;
    private Transform Button4;

    void Start()
    {
        Button4 = GameObject.FindGameObjectWithTag("Object4").transform;
        animator = GetComponent<Animator>();
    }
}
