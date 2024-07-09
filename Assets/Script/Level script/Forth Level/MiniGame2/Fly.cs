using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using static Flyfight;

public enum FlyType
{
    Big,
    Medium,
    Small
}

public class Fly : MonoBehaviour
{
    public static Action _fly;

    public SpriteRenderer spriteRenderer;
    

    [Header("FlyState")]
    public FlyType flyState;
    public int flyHealth;
    public int flyDamage;
    public bool isDamage = false;
    public float speed;
    private Transform Target;
    public bool dying;
    public bool isDead { get; private set; } = false;
    public int swatterDamage;
    public Flyswatter swatter;
    public GameObject fly;

    [Header("Raycast")]
    private Ray ray;
    private RaycastHit hit;
    private Camera mainCamera;

    public Animator ani;

    void Awake()
    {
        mainCamera = Camera.main;
        _fly = () => { FlyDie(); };
    }

    void Start()
    {
        swatter = GameObject.FindObjectOfType<Flyswatter>().GetComponent<Flyswatter>();
        swatterDamage = 1;

        ani = GetComponent<Animator>();

        Target = GameObject.FindGameObjectWithTag("Target").transform; //Trace to player
    }


    void Update()
    {
        if (dying == false)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Target.position, speed * Time.deltaTime);
            //While the fly is alive, it will move towards the specified spot
        }

       /* switch (flyState)
        {
            case FlyType.Big:
                flyHealth = 1;
                flyDamage = 1;
                
                break;

            case FlyType.Medium:
                flyHealth = 1;
                flyDamage = 1;
                break;

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
        //Destroy(this.gameObject);

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
