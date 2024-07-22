using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum Seagulls
{
    Big,
    Medium,
    Small
}

public class Seagull : Singleton<Seagull>
{
    public Seagulls seaqullState;
    public int seaguelHealth;
    public int seaguealDamage;
    public bool isDamage = false;
    public bool isDead { get; private set; } = false;

    void Start()
    {
        
    }

   
    void Update()
    {
        switch (seaqullState)
        {
            case Seagulls.Big:
                seaguelHealth = 200;
                seaguealDamage = 20;
                break;

            case Seagulls.Medium:
                seaguelHealth = 100;
                seaguealDamage = 15;
                break;

            case Seagulls.Small:
                seaguelHealth = 5;
                seaguealDamage = 10;
                break;
        }

        

    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !isDamage)
        {
            isDamage = true;
            int hammerDamage = collision.gameObject.GetComponent<Hammer>().hammerDamage;
            seaguelHealth -= hammerDamage;
            Debug.Log("Hit!");

            if (seaguelHealth <= 0)
            {
                isDead = true;
                PressTheButton(gameObject);
            }
        }

    }*/

    public void SeagueHit(int hammerDamage)
    {
        
        seaguelHealth -= hammerDamage;

        if (seaguelHealth <= 0)
        {
            Debug.Log("GoodBYE");
            SeaguelDie();
        }
    }

    void SeaguelDie()
    {
        StopAllCoroutines();
        Destroy(this.gameObject);
        Debug.Log("Die!");
    }

}
