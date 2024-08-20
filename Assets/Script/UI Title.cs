using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UITitle : MonoBehaviour
{
    
    public void StartButton()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
