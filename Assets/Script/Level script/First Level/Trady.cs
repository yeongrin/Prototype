using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Image tradyImage;
    public TMP_Text tradytext;
    public int trady = 5;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    public void LostTrady()
    {
        trady -= 1;
        SetText();
        if (trady == 0)
        {
            GameOver();
        }
        
    }

    public void SetText()
    {
        tradytext.text = "Elements: " + trady.ToString();
    }

    public void GameOver()
    {

    }
}
