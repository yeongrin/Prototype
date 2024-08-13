using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class KeyClick : MonoBehaviour
{
    public Sprite[] keyStates;
    public Image image;
    public int currentKey;
    bool fadeStart = false;
    public GameObject startScene;

    public AudioSource source;
    public AudioClip carStarting;

    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        if (startScene.activeSelf == true)
            ppVolume.weight = 1f;

        image.sprite = keyStates[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeStart == true)
        {
            PostProcessVolume ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
            ppVolume.weight -= Time.deltaTime;
        }
    }

    public void KeyPress()
    {
        if (currentKey == 0)
            StartCoroutine(KeyChange1());
    }

    

    public IEnumerator KeyChange1()
    {
        image.sprite = keyStates[1];
        ani.SetTrigger("clicking");
        fadeStart = true;
        yield return new WaitForSeconds(1);
        source.Play();
        yield return new WaitForSeconds(3.5f);
        GameObject.Find("StartScene").SetActive(false); GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(true);
        yield return null;
    }



    //public IEnumerator KeyChange2()
    //{
    //    image.sprite = keyStates[2];
    //    currentKey++;
    //    yield return null;
    //}

    //public IEnumerator KeyChange3()
    //{
    //    image.sprite = keyStates[3];
    //    yield return new WaitForSeconds(0.5f);
    //    GameObject.Find("StartScene").SetActive(false); GameObject.Find("Game").transform.Find("Scene1").gameObject.SetActive(true);
    //    yield return null;
    //}
}
