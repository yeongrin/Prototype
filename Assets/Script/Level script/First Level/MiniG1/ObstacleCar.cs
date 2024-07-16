using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCar : MonoBehaviour
{
    public float size;
    public Vector2 orgSize;
    public float time;
    public float speed;
    //public static float countdown = 3f; 

    [Header ("Location")]
    private Transform Button;
    public Transform firstLocation;
    public Transform movingLocation;
    public Transform target;
    public Transform startPos;
    public Transform spawnPoint;
    

    //Vector2 startPos;
  
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
        ani = GetComponent<Animator>();
        _B = GameObject.FindObjectOfType<Button>();
        _MG1 = GameObject.FindObjectOfType<MiniGame1>().GetComponent<MiniGame1>();
        _SE2 = GameObject.FindObjectOfType<SpawnEnemy2>();
        target = Button.transform;
    }

    void Update()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
        

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
        //transform.position = Vector2.MoveTowards(this.transform.position, firstLocation.position, speed * Time.deltaTime);
        Destroy(this.gameObject); //if 3 secs passed, car is destried;
        _MG1.timer1 = 3f;
        _B.isTimer = false;

        //https://onecoke.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B02D-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%EC%9B%90%EB%9E%98-%EC%9E%88%EB%8D%98-%EC%9C%84%EC%B9%98%EB%A1%9C-%EB%8F%8C%EC%95%84%EA%B0%80%EA%B8%B0

    }
}
