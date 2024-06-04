using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclecoin : MonoBehaviour
{
    private Transform Button4;

    void Start()
    {
        Button4 = GameObject.FindGameObjectWithTag("Object4").transform;
    }


    public void DestroyObj()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy4"));
    }
}
