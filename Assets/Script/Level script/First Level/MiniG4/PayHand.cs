using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayHand : MonoBehaviour
{
    private Ray ray;
    private Camera mainCamera;
    public RaycastHit2D hit;
    Animator ani;

    private void Awake()
    {
        mainCamera = Camera.main;
        ani = GetComponent<Animator>();
    }

    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    void Update()
    {
       StartCoroutine("HandMoving");
        if(Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("Payment");
        }
    }

    public void HandVisible()
    {
        this.gameObject.SetActive(true);
    }

    IEnumerator HandMoving()
    {
        Vector2 findHand = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector2(findHand.x, findHand.y);
        yield return null;
    }

    public void HandInvisible()
    {
        this.gameObject.SetActive(false);
        StopCoroutine("HandMoving");
    }
}
