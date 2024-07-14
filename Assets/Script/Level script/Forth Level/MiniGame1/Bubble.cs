using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject questions;
    public GameObject nextquestions;
    public GameObject beforeBubble;
    public GameObject afterBubble;
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

    public void True1()
    {

    }

    public void True2()
    { 
    }

    public void True3()

    {

    }

    public void Wrong(GameObject shakeObject)
    {
        Debug.Log("Wrong answer");
        shakeObject.GetComponent<NewBubble>().Shake();
        //When clicked the object shake from the called script is run on the object that it is hooked up to.
        
    }

    public void NextScene()
    {
        GameObject.Find("Game").transform.Find("Scene2").gameObject.SetActive(true);
        GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
    }
}
