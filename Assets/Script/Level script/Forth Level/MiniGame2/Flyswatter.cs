using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Fly;
using static UnityEngine.ParticleSystem;

public class Flyswatter : MonoBehaviour
{
    public delegate void IncreaseScore();
    public static event IncreaseScore increaseScore;

    [Header("VFX")]
    public Animator animator;
    public ParticleSystem particle = null;
    public ParticleSystem particle2 = null;
    public Transform particlePoint;

    [Header("SwatterFade")]
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

    private RaycastHit2D hitFly;
    public ManFaceChange manFaceChange;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Mat = GetComponent<SpriteRenderer>().material;
        original = Mat.color.a;

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
            animator.SetTrigger("Swat");

            hitFly = Physics2D.Raycast(findFly, Vector2.zero, 0f);
            fadeTimer = 0.5f; //When clicking, a timer will start for the flyswatter to be fully visible before returning to opaque.
            
           if (hitFly.transform.gameObject.tag == "Fly")
           {
                //hitFly.transform.processingObject.GetComponent<SpriteRenderer>().sprite = newSprite;
                //This function changes the sprite of the hit fly to sprite specified in this script in the editor

                hitFly.collider.GetComponent<Fly>().flyCollider.enabled = false;
                hitFly.collider.gameObject.GetComponent<Fly>().dying = true;
                hitFly.collider.gameObject.GetComponent<Animator>().SetTrigger("Death");
                //When hit, the target fly will change sprite and stop moving.
                
               increaseScore();
           }
            if (hitFly.transform.gameObject.tag == "Target")
            {
                manFaceChange.HitLin();
                particle2.Play();
                particle.Play();
                
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

