using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent1 : MonoBehaviour
{
    private bool end1;
    private bool end2;

    public Animator anim1;
   
    public GameObject map1;
    public GameObject map2;

    void Awake()
    {
        anim1 = GetComponent<Animator>();
        
    }

    
    void Start()
    {
        end1 = true;
        end2 = false;
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
        end1 = false;
        end2 = true;
        //Debug.Log("Fine2");
        GameObject.Find("AllMap").transform.Find("1.5").gameObject.SetActive(true);
        GameObject.Find("AllMap").transform.Find("Map1").gameObject.SetActive(false);

    }
}
