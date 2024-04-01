using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSleep : MonoBehaviour
{
    Animator animator;
    private Transform Button3;

    void Start()
    {
        //버튼을 누르면 린이 잠에서 깨는 애니메이션이 재생된다.
        Button3 = GameObject.FindGameObjectWithTag("Object3").transform;
        animator = GetComponent<Animator>();
    }


    public void StartAnimation()
    {
        

    }
}

