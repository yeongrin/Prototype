using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseEvent
{
    Press,
    Click,
    Drag
}

public class Human: MonoBehaviour
{   SpriteRenderer _render;
    public GameObject human;
    EdgeCollider2D ec;

    void Start()
    {
        _render = gameObject.GetComponent<SpriteRenderer>();
        ec = human.GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0);
            
           if (hit.transform.gameObject.tag == "Object1")
            {
              _render.color = Color.black;
              Destroy(gameObject, 3);
              Debug.Log("Black");
            }
           
        }
    }
}
