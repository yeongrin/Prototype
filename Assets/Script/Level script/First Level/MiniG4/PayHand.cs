using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayHand : MonoBehaviour
{
    private Ray ray;
    private Camera mainCamera;
    public RaycastHit2D hit;
    Animator ani;

    public int coin; //Count How many coin is there, if there is more than one coin, Hand keep appear.
    public bool enterOtherScene; //If mouse pointer enter the other scene
 
    private void Awake()
    {
        mainCamera = Camera.main;
        ani = GetComponent<Animator>();
    }

    void Start()
    {
        //this.gameObject.SetActive(false);
        enterOtherScene = false;
    }

    void Update()
    {
        Vector2 findHand = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector2(findHand.x, findHand.y);

        //StartCoroutine("HandMoving");

        if(Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("Payment");
        }
    }

    public void HandVisible()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HandInvisible()
    {
        coin = GameObject.FindGameObjectsWithTag("Enemy4").Length;
        if (coin == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        else
        {
            if (coin > 0)

                return;
        }
        if (enterOtherScene == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            if (enterOtherScene == false)
                return;
        }
     
    }

    public void HandInvisibleOnOtherScene()
    {
        enterOtherScene = true;
    }
}
