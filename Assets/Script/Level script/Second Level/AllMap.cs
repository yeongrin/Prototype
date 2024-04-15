using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMap : MonoBehaviour
{

    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;
    public GameObject map5;
    public GameObject map6;

    /*private bool end1; //Level 1 
    private bool end2; //Level 1.5
    private bool end3; //Level 2
    private bool end4; //Level 3
    private bool end5; //Level 4

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;*/

    void Awake()
    {

        //anim1 = GetComponent<Animator>();
        //anim2 = GetComponent<Animator>();
        //anim3 = GetComponent<Animator>();
        //anim4 = GetComponent<Animator>();
        //anim5 = GetComponent<Animator>();
    }

    void Start()
    { 
        
        //end2 = false;
        //end3 = false;
        //end4 = false;
       // end5 = false;
    }

    void Update()
    {

         

            /*if (anim1.GetCurrentAnimatorStateInfo(0).IsName("WalkLin") == true)
            {
                float animTime = anim1.GetCurrentAnimatorStateInfo(0).normalizedTime;

                if (animTime >= 1.0f)
                { 
       
                    end1 = false;
                    end2 = true;
                    Debug.Log("Fine2");
                    
                if (end2 == true && end1 == false)
                   {
                  
                  GameObject.Find("AllMap").transform.Find("1.5").gameObject.SetActive(true);
                  Destroy(map1);

                if (end3 == true)

                {
                    if (end4 == true)
                    {
                        if(end5 == true)
                        {

                        }
                    }
                        
                }
                     }


                }                         
        

                


            }*/
            
    }

}
