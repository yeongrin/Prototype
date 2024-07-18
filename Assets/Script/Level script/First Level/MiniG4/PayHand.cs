using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayHand : MonoBehaviour
{
    private Ray ray;
    private Camera mainCamera;
    public RaycastHit2D hit;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HandVisible()
    {
        this.gameObject.SetActive(true);
        Vector2 findHand = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector2(findHand.x, findHand.y);

    }

    public void HandInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
