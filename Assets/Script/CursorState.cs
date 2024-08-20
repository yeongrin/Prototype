using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorState : MonoBehaviour
{
    public enum CursorShowing { Visible, Invisible }

    public CursorShowing showCursor;

    void Start()
    {
        
    }

    
    void Update()
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
