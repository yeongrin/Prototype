using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Fly;

public class Flyswatter : MonoBehaviour
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

        Vector2 findFly = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector2(findFly.x, findFly.y);
       
        if (Input.GetMouseButtonDown(0))
        {
            //int mask = (1 << 7);

            animator.SetTrigger("Swat");

            //ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            hitFly = Physics2D.Raycast(findFly, Vector2.zero, 0f);
            fadeTimer = 0.5f; //When clicking, a timer will start for the flyswatter to be fully visible before returning to opaque.
            
           if (hitFly.transform.gameObject.tag == "Fly" && hitFly.collider != null)
           {
                //raycastEvent.Invoke(hitFly.transform);
                //_fly();
                //PressTheButton(hitFly.transform.gameObject,2);

                //hitFly.transform.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
                //This function changes the sprite of the hit fly to sprite specified in this script in the editor

                hitFly.collider.GetComponent<Fly>().flyCollider.enabled = false;
                hitFly.collider.gameObject.GetComponent<Fly>().dying = true;
                hitFly.collider.gameObject.GetComponent<Animator>().SetTrigger("Death");
                //When hit, the target fly will change sprite and stop moving.
                
                hitFly.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
                
               increaseScore();
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

