using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AniEvent2 : MonoBehaviour
{
    private bool end2;
    private bool end3;

    public GameObject map2;
    public GameObject map3;
    public TMP_Text elementsText;
    public int score;

    void Start()
    {
        end2 = true;
        end3 = false;
        SetText();
}

    void SetText()
    {
        elementsText.text = "Lives:" + score.ToString();
    }

    public void NextScene()
    {
        end2 = false;
        end3 = true;
        GameObject.Find("AllMap").transform.Find("2").gameObject.SetActive(true);
    }
}
