using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Animator ani;
    private Transform Button;

    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("Object1").transform;

        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void StartAnimation()
    {
        ani.Play("Key2");
    }

    public void NextScene2()
    {
        GameObject.Find("Canvas").transform.Find("Video").gameObject.SetActive(true);
    }
}
