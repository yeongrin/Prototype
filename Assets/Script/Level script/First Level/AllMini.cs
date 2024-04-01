using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMini : MonoBehaviour
{
    float timer;
    int waitingTime1;
    int waitingTime2;
    int waitingTime3;
   
    public GameObject FirMini;
    public GameObject SecMini;
    public GameObject ThiMini;
    public GameObject ForMini;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime1 = 10;
        waitingTime2 = 20;
        waitingTime3 = 30;
       
        FirMini.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime1)
        {
            GameObject.Find("Game").transform.Find("SecondMini").gameObject.SetActive(true);

            if (timer > waitingTime2)
            {
                GameObject.Find("Game").transform.Find("ThirdMini").gameObject.SetActive(true);

                if (timer > waitingTime3)

                {
                    GameObject.Find("Game").transform.Find("ForthMini").gameObject.SetActive(true);
                }
            }
        }
    }
}
