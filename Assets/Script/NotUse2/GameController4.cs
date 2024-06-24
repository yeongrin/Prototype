using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController4 : MonoBehaviour
{ 
    public int score;
    public GameObject GameEndPanel;
    //int scoreMultiplier = 1;


    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D attacked = Physics2D.Raycast(player, Vector2.zero, 0f);

            if (attacked.transform.gameObject.tag == "elements" && attacked.collider != null)
            {
                ScoreAdd();
            }
            else if (attacked.transform.gameObject.tag == "elements2" && attacked.collider != null)
            {
                ScoreAdd();
            }
            else if (attacked.transform.gameObject.tag == "elements3" && attacked.collider != null)
            {
                ScoreAdd();
            }
            else if(attacked.transform.gameObject.tag == "elements4" && attacked.collider != null)
            {
                ScoreAdd();
            }
        }
    }

    void ScoreAdd()
    {
        score += 1;
            if(score == 4)
        {
            GameEndPanel.SetActive(true);
        }
    }

   public void Restart()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}


