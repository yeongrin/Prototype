using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Flyswatter;

public class Flyfight : MonoBehaviour
{
    public delegate void ActivateScene2();
    public static event ActivateScene2 activateScene2;

    public int score;
    public GameObject map3;
    public GameObject map2;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    RaycastHit2D attacked = Physics2D.Raycast(player, Vector2.zero, 0f);

        //    if (attacked.transform.gameObject.tag == "elements1" && attacked.collider != null)
        //    {
        //        Score();
        //    }
        //    else if (attacked.transform.gameObject.tag == "elements2" && attacked.collider != null)
        //    {
        //        Score();
        //    }
        //    else if (attacked.transform.gameObject.tag == "elements3" && attacked.collider != null)
        //    {
        //        Score();
        //    }
        //}
        
    }

    public void Score()
    {
        score += 1;
        if (score >= 5)
        {
            map3.SetActive(true);
            map2.SetActive(false);
            activateScene2();
        }
    }

    private void OnEnable()
    {
        increaseScore += Score;
    }

    private void OnDisable()
    {
        increaseScore -= Score;
    }

}
