using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSleep : MonoBehaviour
{
    Animator animator;
    private Transform Button3;

    void Start()
    {
        //��ư�� ������ ���� �ῡ�� ���� �ִϸ��̼��� ����ȴ�.
        Button3 = GameObject.FindGameObjectWithTag("Object3").transform;
        animator = GetComponent<Animator>();
    }


    public void StartAnimation()
    {
        

    }
}

