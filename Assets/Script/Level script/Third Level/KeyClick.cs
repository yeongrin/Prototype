using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyClick : MonoBehaviour
{
    public Sprite[] keyStates;
    public Image image;
    public int currentKey;

    // Start is called before the first frame update
    void Start()
    {
        image.sprite = keyStates[0];
        currentKey = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyPress()
    {
        if (currentKey == 0)
            StartCoroutine(KeyChange1());
        else if (currentKey == 1)
            StartCoroutine(KeyChange2());
        else if (currentKey == 2)
            StartCoroutine(KeyChange3());

    }

    

    public IEnumerator KeyChange1()
    {
        image.sprite = keyStates[1];
        currentKey++;
        yield return null;
    }

    public IEnumerator KeyChange2()
    {
        image.sprite = keyStates[2];
        currentKey++;
        yield return null;
    }

    public IEnumerator KeyChange3()
    {
        image.sprite = keyStates[3];
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("StartScene").SetActive(false); GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(true);
        yield return null;
    }
}
