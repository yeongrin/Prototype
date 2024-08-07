using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject questions;
    public GameObject nextquestions;
    public GameObject beforeBubble;
    public GameObject afterBubble;
    public GameObject game1;
    public GameObject game2;

    //control the bubble
    //Click bubble1/bubble 1 disappears and bubble 2 apear(setActiveTRUE)

    public void Wating1()
    {
        StartCoroutine(nextbubble());

    }

    IEnumerator nextbubble()
    {
        yield return new WaitForSeconds(5f);
        afterBubble.SetActive(true);
        beforeBubble.SetActive(false);
        nextquestions.SetActive(true);
        questions.SetActive(false);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Wrong(GameObject shakeObject)
    {
        Debug.Log("Wrong answer");
        shakeObject.GetComponent<NewBubble>().Shake();
        //When clicked the object shake from the called script is run on the object that it is hooked up to.

    }

    public void NextScene()
    {
        StartCoroutine("NextSceneCoroutine");
    }

    IEnumerator NextSceneCoroutine()
    {
        yield return new WaitForSeconds(2f);
        game2.SetActive(true);
        game1.SetActive(false);

    }
}
