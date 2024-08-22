using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Flyswatter;
using UnityEngine.Video;

public class MiniGame2OfLevel4 : MonoBehaviour
{
    //public delegate void ActivateScene2();
    //public static event ActivateScene2 activateScene2;

    public int score;
    public GameObject transitionVideo3;
    public static bool gameEnd = false;
    public GameObject minigame;
    public GameObject thisMinigame;

    void Start()
    {
        score = 0;
        gameEnd = false;
    }

    private void Update()
    {
        if (score >= 12)
        {
            gameEnd = true;
            if (gameEnd == true)
            {
                //Debug.Log("next");
                StartCoroutine("EnterNextScene");
            }
        }
    }

    public void Score()
    {
        score += 1;
        
 
    }

    private void OnEnable()
    {
        increaseScore += Score;
    }

    private void OnDisable()
    {
        increaseScore -= Score;
    }

    IEnumerator EnterNextScene()
    {
        Destroy(GameObject.FindGameObjectWithTag("Fly"));
        yield return new WaitForSeconds(0.5f);
        transitionVideo3.SetActive(true); //transition video play
        thisMinigame.SetActive(false);
        if (minigame != null)
        {
            minigame.SetActive(false);
        }
        else
            yield return null;
        
        //activateScene2();

    }
}
