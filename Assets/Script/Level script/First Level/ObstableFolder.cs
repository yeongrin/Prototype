using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstableFolder : MonoBehaviour
{
    private Transform Button2;

    void Start()
    {
        Button2 = GameObject.FindGameObjectWithTag("Object2").transform;
    }

    
    public void DestroyObj()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy2"));
    }
}
