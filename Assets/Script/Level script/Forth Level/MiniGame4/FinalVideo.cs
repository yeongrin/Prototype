using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalVideo : MonoBehaviour
{
    public GameObject MiniGame3;
    public GameObject MiniGame4;

    CursorState _cs;
    // Start is called before the first frame update
    void Start()
    {
        _cs = FindObjectOfType<CursorState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        _cs.showCursor = CursorState.CursorShowing.Invisible;
        MiniGame4.SetActive(true);
        MiniGame3.SetActive(false);
    }

}
