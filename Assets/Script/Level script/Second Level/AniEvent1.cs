using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent1 : MonoBehaviour
{
    public Animator anim1;
   
    public GameObject map1;
    public GameObject map2;

    void Awake()
    {
        anim1 = GetComponent<Animator>();
        
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
       
        map2.SetActive(true);
        map1.gameObject.SetActive(false);

    }
}
