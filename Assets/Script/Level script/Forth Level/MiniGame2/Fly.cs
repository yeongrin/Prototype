using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using static Flyfight;
using Random = UnityEngine.Random;

/*public enum FlyType
{
    Big,
    Medium,
    Small
}*/

public class Fly : MonoBehaviour
{
    public static Action _fly;
    public SpriteRenderer spriteRenderer;
    
    [Header("FlyState")]
    //public FlyType flyState;
    public int flyHealth;
    public int flyDamage;
    public bool isDamage = false;
    public float speed;

    [Header("Target")]
    public Transform[] mainTarget;
    public GameObject[] targetObjects;
    public Transform currentTarget;

    public bool dying;

    public bool isDead { get; 
    private set; } = false;

    [Header("FlyDeath")]
    public ElectricSwatter electricSwatter;
    public GameObject fly;
    public BoxCollider2D flyCollider;

    public Animator ani;

    void Awake()
    {
        _fly = () => { FlyDie(); };
    }

    void Start()
    {
        electricSwatter = GameObject.FindObjectOfType<ElectricSwatter>().GetComponent<ElectricSwatter>();

        flyCollider = gameObject.GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();

        targetObjects = GameObject.FindGameObjectsWithTag("Target");//Trace to player

        mainTarget = new Transform[4];

        for (int i = 0; i < targetObjects.Length; i++)
        {
            mainTarget[i] = targetObjects[i].transform;

        }

        if (dying == false)
        {
            int randomIndex = Random.Range(0, mainTarget.Length);
            currentTarget = mainTarget[randomIndex];
        }

            speed = Random.Range(2, 4);
      
    }


    void Update()
    {
       
        if (dying == false)
        {
            
            transform.position = Vector2.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);

            //While the fly is alive, it will move towards the specified spot
        }

        /* switch (flyState)
         {
             case FlyType.Small:
                 flyHealth = 1;
                 flyDamage = 1;
                 if (Input.GetMouseButtonDown(0))
                 {
                     Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                     RaycastHit2D attacked3 = Physics2D.Raycast(player, Vector2.zero, 0f);

                     if (attacked3.transform.gameObject.tag == "elements3" && attacked3.collider != null)
                     {
                         isDamage = true;
                         if (isDamage == true)
                         {
                             flyHealth -= swatterDamage;

                         }


                         if (flyHealth <= 0)
                         {
                             ani.SetTrigger("Death");
                            // Invoke("FlyDie", 3f);
                         }
                     }

                 }

                 break;
         }*/

    }

    void FlyDie()
    {
       ani.SetTrigger("Death");
       
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        activateScene2 += FlyDie;
    }

    private void OnDisable()
    {
        activateScene2 -= FlyDie;
    }

}
