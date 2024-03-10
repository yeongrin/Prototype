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
    public int seagullHealth;

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
                seagullHealth = 200;
                break;

            case Seagulls.Medium:
                seagullHealth = 100;
                break;

            case Seagulls.Small:
                seagullHealth = 50;
                break;
        }
    }
}
