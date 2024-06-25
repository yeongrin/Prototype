using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyswatterCollider : MonoBehaviour
{
    public List<GameObject> fliesBelowSwatter;
    public GameObject swatter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Fly"))
            Debug.Log("Enter");
            //fliesBelowSwatter.Add(collision.gameObject);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Fly"))
            Debug.Log("Exit");
        //fliesBelowSwatter.Remove(collision.gameObject);
    }
}
