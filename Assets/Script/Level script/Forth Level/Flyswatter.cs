using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Flyswatter : MonoBehaviour
{
    public int swatterDamage;
    public GameObject swatter;

    public float fadeSpeed, fadeAmount;
    float original;
    Material Mat;
    public bool DoFade = false;

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private Fly fly;
    public int fh;

    void Awake()
    {
        mainCamera = Camera.main;
    }


    void Start()
    {
        swatterDamage = 1;
        fly = GameObject.FindObjectOfType<Fly>().GetComponent<Fly>();

        Mat = GetComponent<SpriteRenderer>().material;
        original = Mat.color.a;

  }

    void Update()
    {
        if (DoFade)

            FadeNow();

        else
            ResetFade();



        Vector2 findFly = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        swatter.transform.position = new Vector2(findFly.x, findFly.y);
       
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitFly = Physics2D.Raycast(findFly, Vector2.zero, 0f);

           if (hitFly.transform.gameObject.tag == "Enemy" && hitFly.collider != null)
            {
                raycastEvent.Invoke(hitFly.transform);
               // fly.AttackFly();

            }

        
        }

    }

    void FadeNow()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }

    void ResetFade()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, original, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }

}

