using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ObstacleCar : MonoBehaviour
{
    public float size = 1f;
    public Vector2 orgSize;
    public float time;
    //public static float countdown = 3f; 

    public float speed;
    private Transform Button;

    [Header("Color Change")]
    //private SpriteRenderer color;
    Animator ani;

    Button _B;
    MiniGame1 _MG1;
    SpawnEnemy2 _SE2;

    private void Awake()
    {
        orgSize = transform.localScale;
    }

    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("Object1").transform;
        //color = GameObject.Find("Car").GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        _B = GameObject.FindObjectOfType<Button>();
        _MG1 = GameObject.FindObjectOfType<MiniGame1>().GetComponent<MiniGame1>();
        _SE2 = GameObject.FindObjectOfType<SpawnEnemy2>();

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Button.position, speed * Time.deltaTime);

        if (_B.isChange == true)
        {
            ani.SetBool("timer 0", true);
        }
        else
        {
            if (_B.isChange == false)
            {
                ani.SetBool("timer 0", false);
              
            }
        }

        //Time passed. Faster more Faster
        if (_SE2.time >= 15)
        {
            speed = 2;

            if (time >= 25)
            {
                speed = 3;
            }
        }

    }

    private void OnEnable()
    {
        StartCoroutine(Up());

    }

    private IEnumerator Up()
    {
        while (transform.localScale.x < size)
        {
            transform.localScale = orgSize * (1f + time * speed);
            time += Time.deltaTime;

            if(transform.localScale.x >= size)
            {
                time = 0;
                break;
            }
            yield return null;
        }
    }

    private void OnDisable()
    {
        gameObject.transform.localScale = orgSize;
    }

    public void DestroyObj()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        _MG1.timer1 = 3f;
        _B.isTimer = false;
        
    }
}
