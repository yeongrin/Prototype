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
        
        map5.SetActive(true);
        map4.gameObject.SetActive(false);

    }
}
