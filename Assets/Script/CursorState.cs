using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorState : MonoBehaviour
{
    public enum CursorShowing { Visible, Invisible }

    public CursorShowing showCursor;

    public GameObject pauseMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        AudioListener.pause = false;
    }

    
    void Update()
    {
        if (pauseMenu.activeSelf)
        {
            Cursor.visible = true;
        }
        else
        {
            switch (showCursor)
            {
                case CursorShowing.Visible:
                    Cursor.visible = true; break;
                case CursorShowing.Invisible:
                    Cursor.visible = false; break;
            }
        }
        
    }
}
