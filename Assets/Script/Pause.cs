using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    CursorState _cs;
    bool cursor;

    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        _cs = FindObjectOfType<CursorState>();
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        if (_cs.showCursor == CursorState.CursorShowing.Visible)
            cursor = true;
        else if(_cs.showCursor == CursorState.CursorShowing.Invisible)
            cursor = false;
        AudioListener.pause = true;
    }

    public void Unpause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        //Cursor.visible = false;
        if(cursor == true)
        {
            Cursor.visible = true;
        }
        else if (cursor == false)
            Cursor.visible = false;
        AudioListener.pause = false;
    }
}
