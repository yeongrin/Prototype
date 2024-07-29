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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public KeyClick()
    {
        if (currentKey == 0)
            StartCoroutine(KeyChange1());
        else if (currentKey == 1)
            StartCoroutine(KeyChange2());

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
        GameObject.Find("StartScene").SetActive(false); GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(true);
        yield return null;
    }
}
