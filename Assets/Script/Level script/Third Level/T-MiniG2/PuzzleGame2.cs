using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleGame2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int snapOffset = 30;
    public JigsawPuzzle2 puzzle;
    public int piece_no;
    public GameObject piecePos;
 

    bool CheckSnapPuzzle()
    {
        for (int i = 0; i < puzzle.puzzlePosSet.transform.childCount; i++)
        {
            if(puzzle.puzzlePosSet.transform.GetChild(i).childCount != 0)
            {
                continue;
            }
            else if(Vector2.Distance(puzzle.puzzlePosSet.transform.GetChild(i).position, transform.position)<snapOffset)
            {
                transform.SetParent(puzzle.puzzlePosSet.transform.GetChild(i).transform);
                transform.localPosition = Vector3.zero;
                return true;
            }
        }
        return false;
    }

    public void Start()
    {
        piece_no = gameObject.name[gameObject.name.Length - 1] - '0';
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
      
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!CheckSnapPuzzle())
        {
            transform.SetParent(puzzle.puzzlePieceSet.transform);
        }
        if(puzzle.IsClear())
        {
            Debug.Log("clear");
            //JigsawPuzzle2.JP2();
            
        }

    }

    //https://game-happy-world.tistory.com/44
}
