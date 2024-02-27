using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class UITitle : MonoBehaviour
{
    
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
    void Update()
    {
        
    }
}
