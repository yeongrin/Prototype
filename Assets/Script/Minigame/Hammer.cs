using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hammer : MonoBehaviour
{
    public int hammerDamage = 50;

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Camera mainCamera;
    // Start is called before the first frame update

    void Awake()
    {
        mainCamera = Camera.main;
    }


    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 findSeaguel = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitSeaguel = Physics2D.Raycast(findSeaguel, Vector2.zero, 0f);

            if (hitSeaguel.transform.gameObject.tag == "Enemy" && hitSeaguel.collider != null)
            {
                raycastEvent.Invoke(hitSeaguel.transform);
            }

        }

    }

}

