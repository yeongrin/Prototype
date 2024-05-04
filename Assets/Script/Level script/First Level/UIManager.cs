using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{ 
    public Image liveImage;
    public TMP_Text livesText;
    public int lives;
    public GameObject gameOverPanel;
    public GameObject EndingPanel;
    public TMP_Text overallTimetext;

    public float goTime;
    public float overTime;


    public float t1;
    void Start()
    {
        goTime = 0f;
        overTime = 50f;
        lives = 5;
        t1 = 5f;
        SetText();
    }


    void Update()
    {
        goTime += Time.deltaTime;

        if (t1 <= 0)

            lives -= 1;
        SetText();


        if (lives == 0)
        {
            GameOver();
        }

        else
        {
            if (goTime >= overTime)
            {
                gameOverPanel.SetActive(true);
            }
        }

    }

    public void SetText()
    {
        livesText.text = "Lives:" + lives.ToString();
        overallTimetext.text = goTime.ToString();
 
    }

    public void GameOver()
    {
        EndingPanel.SetActive(true);
    }
}
