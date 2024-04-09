using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMap : MonoBehaviour
{

    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;

    private bool end1;
    private bool end2;
    private bool end3;
    private bool end4;
    private bool end5;

    // Start is called before the first frame update
    void Start()
    {
        end1 = true;
        end2 = false;
        end3 = false;
        end4 = false;
        end5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (end2 == true)
        {
            end1 = false;
            GameObject.Find("AllMap").transform.Find("1.5").gameObject.SetActive(true);
            Destroy(map1);
        }
    }
}
