using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleEmpty : MonoBehaviour
{
    [SerializeField] 

    private List<Transform> pieces;
    private Vector2Int dimensions;
    private float width;
    private float height;
    private Transform draggingPiece = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            Debug.Log("click");

            if (hit)
            {
                draggingPiece = hit.transform;
                Debug.Log("click2");
            }
        }

        if( draggingPiece && Input.GetMouseButtonUp(0))
        {
            draggingPiece = null;
            Debug.Log("click3");
        }

        if(draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = draggingPiece.position.z;
            draggingPiece.position = newPosition;
            Debug.Log("click4");
        }
    }
}
