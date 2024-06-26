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

    private void Awake()
    {
        orgSize = transform.localScale;
    }

    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("Object1").transform;
        //color = GameObject.Find("Car").GetComponent<SpriteRenderer>();
        _B = GameObject.FindObjectOfType<Button>();
        ani = GetComponent<Animator>();
        _MG1 = GameObject.FindObjectOfType<MiniGame1>().GetComponent<MiniGame1>();

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Button.position, speed * Time.deltaTime);

        if (_B.isChange)
        {
            StartCoroutine("CarColorChange");
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

    IEnumerator CarColorChange()
    {
        //countdown -= Time.deltaTime;
        ani.SetBool("timer", true);
        yield return null;
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
