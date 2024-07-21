using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent3 : MonoBehaviour
{
    private bool end3;
    private bool end4;

    public Animator anim3;

    public GameObject map3;
    public GameObject map4;

    private void Awake()
    {
        anim3 = GetComponent<Animator>();
    }
    void Start()
    {
        end3 = true;
        end4 = false;
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
        end3 = false;
        end4 = true;
        Debug.Log("Fine2");
        map4.SetActive(true);
        map3.gameObject.SetActive(false);

    }
}
