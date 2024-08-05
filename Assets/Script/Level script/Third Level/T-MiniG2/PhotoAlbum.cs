using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public enum Moving
{
    nothing,
    moving
}
public class PhotoAlbum : MonoBehaviour
{
    public int moving;
    int currentState;

    private bool move;

    public GameObject scene2;
    public GameObject GameEndPanel;

    public int score;

    PhotoLoader _Pl;
    ChangeColor _cc;
    PuzzleGame2 _pg2;

    void Start()
    {

        _Pl = FindObjectOfType<PhotoLoader>();
        _cc = FindObjectOfType<ChangeColor>();
        _pg2 = FindObjectOfType<PuzzleGame2>();
        move = false;
        score = 0;

        if (moving != currentState)
        { 
            switch (moving)
            {
            case 1:
            {
                    move = false;

            }
                break;

            case 2:
                {
                    move = true;
                }
                break;

        }

        }

    }


    void Update()
    {
       
    }

    /*public void OnDrop(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("m1");

            Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(player, Vector2.zero, 0f);

            print(hit.ToString());

            if (eventData.pointerDrag != null)
            {
                print("clicked");
                Score();
            }
        }

    }*/

    public void Score()
    {  
        
        score += 1;
        Debug.Log("add");
       
        if (score == _Pl.photosTaken)
        {
            LevelEnd2();
        }
        
    }


    void LevelEnd2()
    {

        //GameObject.Find("Scene3").transform.Find("manyelling").gameObject.SetActive(true);
        GameEndPanel.SetActive(true);
        scene2.SetActive(false);

    }
}
