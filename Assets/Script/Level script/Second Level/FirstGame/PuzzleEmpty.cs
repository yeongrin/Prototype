using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEmpty : MonoBehaviour
{
    [SerializeField] private GameObject emptySpace;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit)
            {
                
            }
        }
    }
}
