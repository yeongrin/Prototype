using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElectricSwatter : MonoBehaviour
{
    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private Transform target;
    public float speed;


    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 FindPlayer = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            RaycastHit2D hitFly = Physics2D.Raycast(FindPlayer, Vector2.zero, 0f);

            if (hitFly.transform.gameObject.tag == "Fly" && hitFly.collider != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
