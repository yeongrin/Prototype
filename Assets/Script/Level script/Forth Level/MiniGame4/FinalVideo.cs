using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalVideo : MonoBehaviour
{
    public GameObject MiniGame3;
    public GameObject MiniGame4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        MiniGame4.SetActive(true);
        MiniGame3.SetActive(false);
    }

}
