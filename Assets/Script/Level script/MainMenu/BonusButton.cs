using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusButton : MonoBehaviour
{
    public GameObject bonusPanel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleBonusImageOn()
    {
        bonusPanel.SetActive(true);
    }

    public void ToggleBonusImageOff()
    {
        bonusPanel.SetActive(false);
    }
}
