using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperaHouse1 : MonoBehaviour
{
    public GameObject operaHouse;
    public GameObject startPoint;
    public GameObject endPoint;

    public Vector2 startPost;
    public Vector2 targetPost;

    public float speed;

    public float startTime;
    public float duration;

    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
        //���콺�� �� ������Ʈ�� Ŭ��������, �� ������Ʈ�� 5�ʵ��� ������ �Ÿ��� �ӵ��� ����� �̵��Ѵ�.

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.transform.gameObject.tag == "Object2" && hit.collider != null)
            {
                float progress = (Time.deltaTime - startTime) / duration;
                progress = Mathf.Clamp(progress, 0, 1);

                Vector2 startPost = startPoint.transform.position;
                Vector2 targetPost = endPoint.transform.position;
                Vector2 originpo = (startPost + (targetPost - startPost) * progress + new Vector2(-1f, 0) * speed);
                transform.position = originpo;
            }
        }

    }
}
