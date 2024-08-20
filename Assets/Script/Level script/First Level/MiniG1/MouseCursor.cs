using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MouseCursor : MonoBehaviour
{
    private Ray ray;
    private Camera mainCamera;
    public RaycastHit2D hit;
    private int layerMask;

    public Sprite[] newSprite;
    public Animator ani;

    [Header("MiniGames")]
    public GameObject miniGame1;
    public GameObject miniGame2;
    public GameObject miniGame3;
    public GameObject miniGame4;

    public GameObject linYell;
    
    Vector2 findHand;
    Transform cursor;
    SpriteRenderer spriteRenderer;

    GameManager _gm;

    //AudioSource audioSource;
    //AudioClip sound;

    public void Awake()
    {
        mainCamera = Camera.main;

        //audioSource = processingObject.GetComponent<AudioSource>();
        //sound = AudioSourceOfLevel1.instance.arraudio[1];
        //audioSource.clip = sound;

    }

    void Start()
    {
        ani = GetComponent<Animator>();
        cursor = this.gameObject.GetComponent<Transform>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        _gm = FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        if (linYell.activeSelf != true)
        {
            findHand = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector2(findHand.x, findHand.y);

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (transform.position.x < 0 && transform.position.y > 0 && miniGame1.activeSelf)
            {
                //spriteRenderer.sprite = newSprite[1];
                //cursor.transform.localScale = new Vector3(1, 1, 1);
                ani.SetTrigger("Mouse1");

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("firstClick");
                    ani.SetTrigger("Press1");
                }
            }
            if (transform.position.x >= 0 && transform.position.y > 0 && miniGame2.activeSelf)
            {
                //spriteRenderer.sprite = newSprite[2];
                //cursor.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                ani.SetTrigger("Mouse2");

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("secondClick");
                    ani.SetTrigger("Press2");
                }
            }
            if (transform.position.x >= 0 && transform.position.y <= 0 && miniGame3.activeSelf)
            {
                //spriteRenderer.sprite = newSprite[3];
                //cursor.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                ani.SetTrigger("Mouse3");

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("thirdClick");
                    ani.SetTrigger("Press3");
                }
            }
            if (transform.position.x < 0 && transform.position.y < 0 && miniGame4.activeSelf)
            {
                //spriteRenderer.sprite = newSprite[4];
                //cursor.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                ani.SetTrigger("Mouse4");

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("forthClick");
                    ani.SetTrigger("Press4");
                }
            }
        }
        else
            this.gameObject.SetActive(false);
        
    }

    public void HandVisibleOnFirstMini()
    {
        layerMask = 1 << 10;
        hit = Physics2D.Raycast(findHand, Vector2.zero, 1f, LayerMask.GetMask("Scene1"));
        if (hit.collider != null)
        {
            //ani.SetBool("Mouse1", true);
            //ani.SetBool("Mouse2", false);
            //ani.SetBool("Mouse3", false);
            //ani.SetBool("Mouse4", false);

            if (Input.GetMouseButtonDown(0))
            {
                ani.SetTrigger("Press1");
            }

        }

    }

    public void HandVisibleOnSecondMini()
    {
        layerMask = 1 << 11;
        hit = Physics2D.Raycast(findHand, Vector2.zero, 1f, LayerMask.GetMask("Scene2"));
        if (hit.collider != null)
        {

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
