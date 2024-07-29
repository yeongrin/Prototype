using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPhoto : MonoBehaviour
{
    public bool hasBonusPhoto;
    GameObject bonusButton;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("bonus");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        

        
    }

    private void Start()
    {
        bonusButton = GameObject.Find("Bonus");

        if (hasBonusPhoto == false)
        {
            bonusButton.SetActive(false);
        }
        else
            bonusButton.SetActive(true);
    }
}
