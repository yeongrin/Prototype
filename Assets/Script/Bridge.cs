using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject bridge;
    public GameObject startPoint2;
    public GameObject endPoint2;

    public Vector2 startPost2;
    public Vector2 targetPost2;

    public float speed;

    public float startTime2;
    public float duration2;
    //Don't write the code same with other name. 
    
    void Start()
    {
        startTime2 = Time.time;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
            {
                float progress = (Time.deltaTime - startTime2) / duration2;
                progress = Mathf.Clamp(progress, 0, 1);

                Vector2 startPost2 = startPoint2.transform.position;
                Vector2 targetPost2 = endPoint2.transform.position;
                Vector2 originpo2 = (startPost2 + (targetPost2 - startPost2) * progress + new Vector2(0, -1f) * speed);
                transform.position = originpo2;

            }
        }
    }
}
