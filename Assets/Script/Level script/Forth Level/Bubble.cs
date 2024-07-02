using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject questions;
    public GameObject nextquestions;
    public GameObject before;
    public GameObject bubble;
    //control the bubble
    //Click bubble1/bubble 1 disappears and bubble 2 apear(setActiveTRUE)

    public void nextbubble()
    {
        bubble.SetActive(true);
        before.SetActive(false);
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

    public void Wrong()
    {
        Debug.Log("Wrong answer");
        
        
    }

    public void NextScene()
    {
        GameObject.Find("Game").transform.Find("Scene2").gameObject.SetActive(true);
        GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(false);
    }
}
