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
    AudioSource electricSound;

    Fly _f;

    public float fadeSpeed, fadeAmount;
    float original;
    Material Mat;
    public bool DoFade = false;

    public Sprite newSprite;
    public float fadeTimer;
    public ParticleSystem particle;

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit2D hitFly;
    public LayerMask enemyLayer;

    public GameObject[] findflies;

    public int killedFlies;

    public MiniGame2OfLevel4 mini;

    void Awake()
    {
        mainCamera = Camera.main;
    }


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Mat = GetComponent<SpriteRenderer>().material;
        original = Mat.color.a;
        electricSound = gameObject.GetComponent<AudioSource>();

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

           
            // if hit the first spider, electric effect does not produce

            if (killedFlies >= 1) // <-int that distinguishes the first spider
            {

                //When 30 spiders appear, a single mouse click create an electrical effect
                //All 30 spiders are played in an animation that burn black
                //After the animation ends, spiders fall down!


                if (hitFly.transform.gameObject.tag == "Fly" && hitFly.collider != null)
                {
                    GameObject[] flies = GameObject.FindGameObjectsWithTag("Fly");
                    foreach (GameObject thisisfly in flies) // create loop to gather 30 spider 
                    {

                        if (thisisfly.name == "Fly2(Clone)")
                        {
                            electricSound.Play();
                            particle.Play(); //electric effect
                            Animator flyAnimator;

                            flyAnimator = thisisfly.GetComponent<Animator>();

                            // burnning animation
                            flyAnimator.SetTrigger("Death");
                            hitFly.collider.gameObject.GetComponent<Fly>().dying = true;
                            thisisfly.GetComponent<Fly>().struckByElectricSwatter();

                            mini.score += 1;
                        }
                    }
                }


            }
            else
            {
                if (killedFlies < 1) // <- first spider
                {
                    if (hitFly.transform.gameObject.tag == "Fly" && hitFly.collider != null)
                    {

                        hitFly.collider.gameObject.GetComponent<Fly>().dying = true;
                        hitFly.collider.gameObject.GetComponent<Animator>().SetTrigger("Death");
                        hitFly.collider.GetComponent<Fly>().flyCollider.enabled = false;
                        killedFlies += 1;

                        mini.score += 1;
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

