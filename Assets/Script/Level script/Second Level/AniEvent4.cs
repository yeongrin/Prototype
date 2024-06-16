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

    public void OnEnterNextScene()
    {
        end4 = false;
        end5 = true;
        
        GameObject.Find("AllMap").transform.Find("4").gameObject.SetActive(true);
        GameObject.Find("AllMap").transform.Find("3").gameObject.SetActive(false);

    }
}
