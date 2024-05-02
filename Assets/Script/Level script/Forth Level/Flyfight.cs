using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyfight : MonoBehaviour
{
    public int flyfight;
    public GameObject map3;
    public GameObject map2;

    // Start is called before the first frame update
    void Start()
    {
        flyfight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D attacked = Physics2D.Raycast(player, Vector2.zero, 0f);

            if (attacked.transform.gameObject.tag == "elements" && attacked.collider != null)
            {
                Score();
            }
            else if (attacked.transform.gameObject.tag == "elements2" && attacked.collider != null)
            {
                Score();
            }
            else if (attacked.transform.gameObject.tag == "elements3" && attacked.collider != null)
            {
                Score();
            }
        }
        
    }

    public void Score()
    {
        flyfight += 1;
        if (flyfight == 5) //나중에 수정
        {
            map3.SetActive(true);
            map2.SetActive(false);
        }
    }

}
