using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum FlyType
{
    Big,
    Medium,
    Small
}

public class Fly : MonoBehaviour
{
    public FlyType flyState;
    public int flyHealth;
    public int flyDamage;
    public bool isDamage = false;
    public bool isDead { get; private set; } = false;

    public int swatterDamage;

    public Flyswatter swatter;

    public GameObject fly;

    private Ray ray;
    private RaycastHit hit;
    private Camera mainCamera;

   /* private void SetEnemyState(int _swatterDamage)
    {
        swatterDamage = _swatterDamage;
        Debug.Log("damge");
    }*/

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        swatter = GameObject.FindObjectOfType<Flyswatter>().GetComponent<Flyswatter>();
        swatterDamage = 1;


    }

   
    void Update()
    {

        switch (flyState)
        {
            case FlyType.Big:
                flyHealth = 5;
                flyDamage = 3;
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D attacked = Physics2D.Raycast(player, Vector2.zero, 0f);

                    if (attacked.transform.gameObject.tag == "elements" && attacked.collider != null)
                    {
                        isDamage = true;
                        if (isDamage == true)
                        {
                            flyHealth -= swatterDamage;
                            Debug.Log("Attack!!!");

                        }


                        if (flyHealth <= 0)
                        {
                            FlyDie();
                        }
                    }

                }
                break;

            case FlyType.Medium:
                flyHealth = 3;
                flyDamage = 2;
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D attacked2 = Physics2D.Raycast(player, Vector2.zero, 0f);

                    if (attacked2.transform.gameObject.tag == "elements2" && attacked2.collider != null)
                    {
                        isDamage = true;
                        if (isDamage == true)
                        {
                            flyHealth -= swatterDamage;
                            Debug.Log("Attack!!!2");

                        }


                        if (flyHealth <= 0)
                        {
                            FlyDie();
                        }
                    }

                }
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
                            Debug.Log("Attack!!!3");

                        }


                        if (flyHealth <= 0)
                        {
                            FlyDie();
                        }
                    }

                }
                
                break;
        }

    }

   /*public void AttackFly()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D attacked = Physics2D.Raycast(player, Vector2.zero, 0f);

            if (attacked.transform.gameObject.tag == "Enemy" && attacked.collider != null)
        {
            isDamage = true;
                if (isDamage == true)
                { 
                    flyHealth -= swatterDamage;
            Debug.Log("Attack!!!");

                }
           

            if (flyHealth <= 0)
            {
                FlyDie();
            }
        }

        }
       
    }*/

    void FlyDie()
    {
        Destroy(this.gameObject);
        Debug.Log("Die!");
    }

}
