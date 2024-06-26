using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;

    private bool check;
    public bool isTimer;
    public bool isChange = false;

    MiniGame1 _MG1;

    public void Awake()
    {
        isTimer = false;
        //check = false;
        //orgColor = new Color(1f, 1f, 1f, 1f);
    }

    void Start()
    {
        _MG1 = GameObject.FindObjectOfType<MiniGame1>().GetComponent<MiniGame1>();
    }


    void Update()
    {
        if (isTimer)
        {
            _MG1.timer1 -= Time.deltaTime;
             
        }

    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.gameObject.tag == "Enemy")
        {
            isTimer = true;
            isChange = true;
      
        }
    }
   
}
