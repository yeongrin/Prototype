using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent5 : MonoBehaviour
{
    private bool end5;
    private bool end6;

    public Animator anim5;

    public GameObject map5;
    public GameObject map6;

    void Awake()
    {
        anim5 = GetComponent<Animator>();
    }
    void Start()
    {
        end5 = true;
        end6 = false;
    }

    public void OnEnterNextScene()
    {
        end5 = false;
        end6 = true;
       
        GameObject.Find("AllMap").transform.Find("5").gameObject.SetActive(true);
        GameObject.Find("AllMap").transform.Find("4").gameObject.SetActive(false);

    }
}
