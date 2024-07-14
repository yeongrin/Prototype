using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject beforeScene;
    public GameObject afterScene;
    public GameObject nextquestions;
    public GameObject questions;
    public GameObject clapObject;
    public GameObject gameEndingPanel;

    void Start()
    {
        gameEndingPanel.SetActive(false);
        afterScene.SetActive(false);
    }


    void Update()
    {

    }

    public void Wating1()
    {
        StartCoroutine(NextGame());
       
      
    }

    IEnumerator NextGame()
    {
        clapObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        afterScene.SetActive(true);
        beforeScene.SetActive(false);
        nextquestions.SetActive(true);
        questions.SetActive(false);
        clapObject.SetActive(false);
    }

    public void Wating2()
    {

        StartCoroutine(NextGame2());
        //린이 비디오를 만드는 것을 끝내면 이쪽에다가 lin이 만든 비디오를 부르는 스크립트를 추가할 것. (ex. 소세지를 먹는 린
        //아보카도를 먹는 린)
    }

    IEnumerator NextGame2()
    {
        clapObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        afterScene.SetActive(true);
        gameEndingPanel.SetActive(true);

    }
}
