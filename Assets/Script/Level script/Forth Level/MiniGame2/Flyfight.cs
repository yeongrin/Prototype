using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Flyswatter;

public class Flyfight : MonoBehaviour
{
    public delegate void ActivateScene2();
    public static event ActivateScene2 activateScene2;

    public int score;
    public GameObject map3;
    public GameObject map2;

    void Start()
    {
        score = 0;
    }

    public void Score()
    {
        score += 1;
        if (score >= 20)
        {
            StartCoroutine("SceneChange");
        }
    }

    private void OnEnable()
    {
        increaseScore += Score;
    }

    private void OnDisable()
    {
        increaseScore -= Score;
    }

    IEnumerator SceneChange()
    {
       yield return new WaitForSeconds(10f);
       map3.SetActive(true);
       map2.SetActive(false);
       activateScene2();
    }
}
