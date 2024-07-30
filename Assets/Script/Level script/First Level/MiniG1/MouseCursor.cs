using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Ray ray;
    private Camera mainCamera;
    public RaycastHit2D hit;
    private int layerMask;

    public Animator ani;
    Vector2 findHand;

    Transform cursor;
    SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;

    public void Awake()
    {
        mainCamera = Camera.main;
        ani = GetComponent<Animator>();
    }

    void Start()
    {
        cursor = this.gameObject.GetComponent<Transform>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        findHand = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector2(findHand.x, findHand.y);

    }

    public void HandVisibleOnFirstMini()
    {
        layerMask = 1 << 10;
        hit = Physics2D.Raycast(findHand, Vector2.zero, 1f, LayerMask.GetMask("Scene1"));
        if (hit.collider != null)
        {

            Debug.Log("firstlevel" + hit.collider.gameObject.name);

            ani.SetBool("Mouse1", true);
            ani.SetBool("Mouse2", false);
            ani.SetBool("Mouse3", false);
            ani.SetBool("Mouse4", false);

            if (Input.GetMouseButtonDown(0))
            {
                ani.SetTrigger("Press1");
            }

            // StartCoroutine("Coroutine1"); 
            //cursor.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }

    }

    public void HandVisibleOnSecondMini()
    {
        layerMask = 1 << 11;
        hit = Physics2D.Raycast(findHand, Vector2.zero, 1f, LayerMask.GetMask("Scene2"));
        if (hit.collider != null)
        {

            Debug.Log("secondlevel" + hit.collider.gameObject.name);

            ani.SetBool("Mouse2", true);
            ani.SetBool("Mouse1", false);
            ani.SetBool("Mouse3", false);
            ani.SetBool("Mouse4", false);

            if (Input.GetMouseButtonDown(0))
            {
                ani.SetTrigger("Press2");
            }

            //spriteRenderer.sprite = newSprite[2];
            //cursor.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            // StartCoroutine("Coroutine2");
        }
        
    }

    public void HandVisibleOnThirdMini()
    {
        layerMask = 1 << 13;
        hit = Physics2D.Raycast(findHand, Vector2.zero, 1f, LayerMask.GetMask("Scene3"));
        if (hit.collider != null)
        {

            Debug.Log("ThirdLevel" + hit.collider.gameObject.name);

            ani.SetBool("Mouse3", true);
            ani.SetBool("Mouse1", false);
            ani.SetBool("Mouse2", false);
            ani.SetBool("Mouse4", false);

            if (Input.GetMouseButtonDown(0))
            {
                ani.SetTrigger("Press3");
            }
        }

        //spriteRenderer.sprite = newSprite[3];
        //cursor.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        //StartCoroutine("Coroutine3");

    }

    public void HandVisibleOnForthMini()
    {
        layerMask = 1 << 14;
        hit = Physics2D.Raycast(findHand, Vector2.zero, 1f, LayerMask.GetMask("Scene4"));
        if (hit.collider != null)
        {

            Debug.Log("SecondLevel" + hit.collider.gameObject.name);

            ani.SetBool("Mouse4", true);
            ani.SetBool("Mouse1", false);
            ani.SetBool("Mouse2", false);
            ani.SetBool("Mouse4", false);

            if (Input.GetMouseButtonDown(0))
            {
                ani.SetTrigger("Press4");
            }
        }

        //spriteRenderer.sprite = newSprite[4];
        //cursor.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        //cursor.transform.rotation = Quaternion.Euler (0, 0, -25);
        // StartCoroutine("Coroutine4");


    }

}
