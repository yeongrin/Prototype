using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private GameObject car;
    public Animator ani;

    private bool check;
    public bool isTimer;
    public bool isChange = false;

    public Transform[] movePoints;

    MiniGame1 _MG1;
    ObstacleCar _oc;
    SpawnEnemy2 _SE2;
    public int speed = 5;

    public void Awake()
    {
        isTimer = false;
        //check = false;
        //orgColor = new Color(1f, 1f, 1f, 1f);
    }

    void Start()
    {
        _MG1 = GameObject.FindObjectOfType<MiniGame1>().GetComponent<MiniGame1>();
        _SE2 = GameObject.FindObjectOfType<SpawnEnemy2>().GetComponent<SpawnEnemy2>();
    }


    void Update()
    {
        if (isTimer)
        {
            _MG1.timer1 -= Time.deltaTime;     
        }
    

    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.gameObject.tag == "Enemy")
        {
            isTimer = true;
            isChange = true;

        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Enemy")
            {
                isTimer = false;
                isChange = false;
            }
    }

    public void Destroy()
    {
        _oc = GameObject.FindObjectOfType<ObstacleCar>();
        car = GameObject.FindGameObjectWithTag("Enemy").gameObject;
        //car.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(-10,2), speed * Time.deltaTime);
        Destroy(car.gameObject, 2);
        _oc.target = _SE2.spawnPoint;
        //Once the button is pressed, the onscreen car will move towards the origin point before being destroyed after a set amount of time.
        _oc.speed = 5f;
        ani.SetTrigger("press");
    }

}
