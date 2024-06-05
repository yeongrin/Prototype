using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    private Flyswatter _swatter;
    private RaycastHit hit;
    private Camera mainCamera;

    void Start()
    {
        
    }

    
    void Update()
    {
        GameObject fly = GameObject.FindGameObjectWithTag("elements");
        GameObject fly2 = GameObject.FindGameObjectWithTag("elements2");
        GameObject fly3 = GameObject.FindGameObjectWithTag("elements3");

        if (fly != null)
        {
            Vector2 findFly = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            RaycastHit2D hit = Physics2D.Raycast(findFly, Vector2.zero, 0f);
            

           
                if (hit.collider == null)
                    return;

                if (hit.collider.gameObject == fly)
                {
                    if (_swatter != null)
                    {
                        _swatter.DoFade = false;
                    }
                }
                else
                {
                    _swatter = hit.collider.gameObject.GetComponent<Flyswatter>();
                    if (_swatter != null)
                    {
                        _swatter.DoFade = true;
                    }
                }
            
        }
    }
}
