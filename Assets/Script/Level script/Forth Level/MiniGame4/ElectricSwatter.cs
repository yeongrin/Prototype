using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Fly;

public class ElectricSwatter : MonoBehaviour
{
    public delegate void IncreaseScore();
    public static event IncreaseScore increaseScore;

    public Animator animator;
 
    Fly _f;

    public float fadeSpeed, fadeAmount;
    float original;
    Material Mat;
    public bool DoFade = false;

    public Sprite newSprite;
    public float fadeTimer;

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit2D hitFly;
    public LayerMask enemyLayer;

    //public Transform[] flies;
    public GameObject[] findflies;

    public int killedFlies;

    void Awake()
    {
        mainCamera = Camera.main;
    }


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Mat = GetComponent<SpriteRenderer>().material;
        original = Mat.color.a;

        _f = FindObjectOfType<Fly>();

        killedFlies = 0;
    }

    void Update()
    {
        if (DoFade)

            FadeNow();

        else
            ResetFade();

        if (fadeTimer > 0)
        {
            DoFade = true;
            fadeTimer -= Time.deltaTime;
            //When the timer hits zero, the fly swatter returns to transparent.
        }
        else
            DoFade = false;

        Vector2 findSwatter = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector2(findSwatter.x, findSwatter.y);

        findflies = GameObject.FindGameObjectsWithTag("Fly");//Trace to player


        if (Input.GetMouseButtonDown(0))
        {
            //int mask = (1 << 7);

            animator.SetTrigger("Swat");

            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            hitFly = Physics2D.Raycast(findSwatter, Vector2.zero, 0f);
            fadeTimer = 0.5f; //When clicking, a timer will start for the flyswatter to be fully visible before returning to opaque.

           
            if (killedFlies >= 1)
            {
                    GameObject[] flies = GameObject.FindGameObjectsWithTag("Fly");

                foreach (GameObject thisisfly in flies)
                {
                    if (Input.GetMouseButton(0))
                    {

                        if (thisisfly.name == "Fly2")
                        {
                            Rigidbody2D flyRigidbody;
                            Collider2D flycollider;
                            Animator flyAnimator;

                            flyAnimator = thisisfly.GetComponent<Animator>();
                            flyRigidbody = thisisfly.GetComponent<Rigidbody2D>();
                            flycollider = thisisfly.GetComponent<Collider2D>();

                            flyAnimator.SetTrigger("Death");
                            flyRigidbody.gravityScale = 1.5f;
                            flycollider.enabled = false;
                            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

                        }
                    }
                }
                   
            }
            else
            {
                if (killedFlies < 1)
                {
                    if (hitFly.transform.gameObject.tag == "Fly" && hitFly.collider != null)
                    {

                        hitFly.collider.gameObject.GetComponent<Animator>().SetTrigger("Death");
                        hitFly.collider.GetComponent<Fly>().flyCollider.enabled = false;
                        hitFly.collider.gameObject.GetComponent<Fly>().dying = true;
                        killedFlies += 1;

                    }

                }
            }
        }
    }

    void FadeNow()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, original, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }

    void ResetFade()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }
}

