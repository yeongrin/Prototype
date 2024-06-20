using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Hammer : Singleton<Hammer>
{
    public int hammerDamage = 50;
    public GameObject hammer;

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    void Awake()
    {
        mainCamera = Camera.main;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 findSeaguel = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        hammer.transform.position = new Vector2(findSeaguel.x, findSeaguel.y);
       
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitSeaguel = Physics2D.Raycast(findSeaguel, Vector2.zero, 0f);

           if (hitSeaguel.transform.gameObject.tag == "Enemy" && hitSeaguel.collider != null)
            {
                raycastEvent.Invoke(hitSeaguel.transform);
                _SG.SeagueHit(hammerDamage);


                Debug.Log("attack!");
            }

            /*if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                raycastEvent.Invoke(hit.transform);
                Debug.Log("attack!");
            }*/

        }

    }

}

