using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Flyswatter;

public class Flyfight : MonoBehaviour
{
    public delegate void ActivateScene2();
    public static event ActivateScene2 activateScene2;

    public int score;
    public GameObject map3;
    public GameObject map2;
    public static bool gameEnd = false;

    public Image image2;
    private bool checkbool = false;

    void Start()
    {
        score = 0;
        gameEnd = false;
    }

    public void Score()
    {
        score += 1;
        if (score >= 12)
        {
            gameEnd = true;
            if (gameEnd == true)
            {
                StartCoroutine("SceneChange");
            }
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
        Color color = image2.color;

        for (int i = 0; i <= 255; i++)
        {
            color.a += Time.deltaTime * 0.01f;

            image2.color = color;

            if (image2.color.a >= 255)
            {
                checkbool = true;
            }
        }
        yield return null;

        StartCoroutine("EnterNextScene");
    }

    IEnumerator EnterNextScene()
    {
       yield return new WaitForSeconds(3f);
       map3.SetActive(true);
       map2.SetActive(false);
       activateScene2();

    }
}
