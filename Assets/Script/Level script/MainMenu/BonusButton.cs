using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusButton : MonoBehaviour
{
    public GameObject bonusPanel;
    public GameObject button;
    BonusPhoto _bp;

    void Start()
    {
        _bp = FindObjectOfType<BonusPhoto>();
        if (_bp.hasBonusPhoto == true)
            button.SetActive(true);
        else
            button.SetActive(false);
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
