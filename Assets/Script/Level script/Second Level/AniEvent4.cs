using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent4 : MonoBehaviour
{
    private bool end4;
    private bool end5;

    public Animator anim4;

    public GameObject map4;
    public GameObject map5;

    public void Awake()
    {
        anim4 = GetComponent<Animator>();
    }
    void Start()
    {
        end4 = true;
        end5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterNextScene1()
    {
        // anim1.Play("WalkLin");
    }

    public void OnEnterNextScene()
    {
        end4 = false;
        end5 = true;
        Debug.Log("Fine2");
        GameObject.Find("AllMap").transform.Find("4").gameObject.SetActive(true);
        GameObject.Find("AllMap").transform.Find("3").gameObject.SetActive(false);

    }
}
