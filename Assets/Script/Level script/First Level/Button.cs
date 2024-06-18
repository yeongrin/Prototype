using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
    SpriteRenderer _render;

    private Color orgColor;
    private bool check;

    public void Awake()
    {
        //check = false;
        //orgColor = new Color(1f, 1f, 1f, 1f);
    }

    void Start()
    {
        _render = gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    { 


    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.gameObject.tag == "Enemy")
        {
            MiniGame1.lives -= 1;
            print("crash!!!!");
        }
    }

}
