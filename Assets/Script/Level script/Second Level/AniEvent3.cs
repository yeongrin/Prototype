using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent3 : MonoBehaviour
{
   
    public Animator anim3;

    public GameObject map3;
    public GameObject map4;

    private void Awake()
    {
        anim3 = GetComponent<Animator>();
    }
    void Start()
    {
    }

   
    void Update()
    {
        
    }

    public void EnterNextScene1()
    {
        // anim1.Play("WalkLin");
    }

    public void OnEnterNextScene()
    {
        Debug.Log("Fine2");
        map4.SetActive(true);
        map3.gameObject.SetActive(false);

    }
}
