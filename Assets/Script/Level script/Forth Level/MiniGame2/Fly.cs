using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using static MiniGame2OfLevel4;
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
    Rigidbody2D rigid;

    public Animator ani;
    public AudioSource audioSource;
    public AudioSource audioSource2;

    public float time; // Fly is destroyed automatically 

    void Awake()
    {
        _fly = () => { FlyDie(); };
    }

    void Start()
    {
        electricSwatter = GameObject.FindObjectOfType<ElectricSwatter>().GetComponent<ElectricSwatter>();
        targetObjects = GameObject.FindGameObjectsWithTag("Target");//Trace to player

        flyCollider = gameObject.GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

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
        if(dying == true)
        {
            audioSource2.Play();
        }

            speed = Random.Range(2, 4);
      
    }


    void Update()
    {
        time += Time.deltaTime;
       
        if (dying == false)
        {
            
            transform.position = Vector2.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);

            //While the fly is alive, it will move towards the specified spot
        }
        if(dying == true)
        {

        }

        if(time >= 4)
        {
            Destroy(this.gameObject);
        }

    }

    public void AudioEffect()
    {
        audioSource.Play();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void FlyDie()
    {
        rigid.gravityScale = 1.5f;
    }

    public void OnBecameInvisible()
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
