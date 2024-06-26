using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclecoin : MonoBehaviour
{
    MiniGame4 _MG4;
    Animator ani;

    public void Start()
    {
        ani = GetComponent<Animator>();
        _MG4 = GameObject.FindObjectOfType<MiniGame4>().GetComponent<MiniGame4>();
    }

    void Update()
    {
        if (_MG4.isChange == true)
        {
            ChangeFileColor();
        }
    }

    void ChangeFileColor()
    {
        ani.SetBool("timer", true);
    }

    public void DestroyObj()
    {
        Destroy(this.gameObject);

    }
}
