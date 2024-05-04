using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public GameObject Scene1;
    public GameObject Scene2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Scene2.SetActive(true);
            Scene1.SetActive(false);
        }
    }
}
