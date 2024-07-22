using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperaHouse : MonoBehaviour
{
    public GameObject startposition; 
    public GameObject transformPosition;
    EdgeCollider2D rangeCol;
    public float speed;
    public Vector2 startPost;
    public Vector2 targetPost;
    //public Vector2 targetPost = new Vector2(-15f, -2.48f);

    public float startTime;
    public float duration;
    
    void Awake()
    {
        startTime = Time.deltaTime;
        rangeCol = transformPosition.GetComponent<EdgeCollider2D>();
        transformPosition = GameObject.FindGameObjectWithTag("TargetPosition1");
    }

    void Update()
    {
        /*float progress = (Time.time - startTime) / duration;
        progress = Mathf.Clamp(progress, 0, 1);
        Vector2 newPos = (startPost + (targetPost - startPost) * progress + new Vector2(0, 0.5f));
        transform.position = newPos;

        if (progress >= 1)
            gameObject.SetActive(false);*/

        /*if(Input.GetMouseButtonUp(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            //transform.position = transform.position + new Vector3(10, 0, 0) * 1 * Time.deltaTime;
            
        }
        transform.position = Vector2.SmoothDamp(gameObject.transform.position, transformPosition.transform.position, ref startPost, speed * Time.deltaTime);
        PressTheButton(this.gameObject, 3);*/

        if (Input.GetMouseButtonUp(0))
        {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.transform.gameObject.tag == "Object2")
            {
                float progress = (Time.deltaTime - startTime) / duration;
                progress = Mathf.Clamp(progress, 0, 1);

                Vector2 startPost = startposition.transform.position;
                Vector2 targetPost = startposition.transform.position;
                Vector2 originpo = (startPost + (targetPost - startPost) * progress + new Vector2(-1f, 0) * speed);
                transform.position = originpo;
            }

        }
        
    }

    /*private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), string.Format("Time : {0}", Time.realtimeSinceStartup));

    }*/

}
