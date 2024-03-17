using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Seagulls
{
    Big,
    Medium,
    Small
}

public class Seagull : MonoBehaviour
{
    public Seagulls seaqullState;
    public int seaguelHealth;
    public int seaguealDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    void hitSeaguel(int _hammerDamage)
    {
        seaguelHealth -= _hammerDamage;
    }


    void SeaguelDie(int _)
    {
        StopAllCoroutines();
        Destroy(this.gameObject);
        Debug.Log("Die!");
    }

}
