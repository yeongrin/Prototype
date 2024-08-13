using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Photo2 : MonoBehaviour
{
 
    public GameObject cameraObject;

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private Color orgColor;

    SpriteRenderer render;

    void Awake()
    {
        mainCamera = Camera.main;
        render = GetComponent<SpriteRenderer>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 findPhoto = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        cameraObject.transform.position = new Vector2(findPhoto.x, findPhoto.y);

       /*if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D takePhoto = Physics2D.Raycast(findPhoto, Vector2.zero, 0f);

            if (takePhoto.transform.processingObject.name == "elements" && takePhoto.collider != null)
            {
                raycastEvent.Invoke(takePhoto.transform);
                Debug.Log("attack!");
                //StartCoroutine("Fade");
            }

            else if (takePhoto.transform.processingObject.tag == "elements2" && takePhoto.collider != null)
            {
                raycastEvent.Invoke(takePhoto.transform);
                Debug.Log("attack!2");
            }

            else if (takePhoto.transform.processingObject.tag == "elements3" && takePhoto.collider != null)
            {
                raycastEvent.Invoke(takePhoto.transform);
                Debug.Log("attack!3");
            }

        }*/

    }
}
