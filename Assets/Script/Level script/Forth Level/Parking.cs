using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parking : MonoBehaviour
{
    public GameObject car;
    Animator animator;

    public float DoubleClickSpeed = 0.25f;
    public float ThirdClickSpeed = 0.5f;
    private bool isOneClick = false;
    private bool isSecClick = false;
    private double Timer2 = 0;
    private double Timer3 = 0;

    public GameObject Scene;
    public GameObject NextScene;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isOneClick&!isSecClick)
            {

                Timer2 = Time.time;
                Timer3 = Time.time;
                isOneClick = true;
                isSecClick = false;
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                {
                    animator.SetTrigger("Park");
                    Debug.Log("443245325");
                    

                }
            }
            else if (isOneClick&!isSecClick)
            {

                Timer2 = Time.time;
                Timer3 = Time.time;
                isOneClick = false;
                isSecClick = true;
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                {

                    animator.SetTrigger("Park2");
                    Debug.Log("eetwtw");
                   


                }
            }
            else 
            {
                Timer2 = Time.time;
                Timer3 = Time.time;
                isOneClick = false;
                isSecClick = false;
                Debug.Log("fjsdkf");
                animator.SetTrigger("Park3");
                Bonk();
            }
        }
    }

    public void Bonk()
    {
        GameObject.Find("Scene3").transform.Find("CRASH").gameObject.SetActive(true);
    }

    public void SceneChange()
    {
        NextScene.SetActive(true);
        Scene.SetActive(false);
    }
}
