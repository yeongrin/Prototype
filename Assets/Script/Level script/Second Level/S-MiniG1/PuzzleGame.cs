using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleGame : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int snapOffset = 30;
    public JigsawPuzzle puzzle;
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
            JigsawPuzzle.JP();
            
        }

    }

    //https://miniGame3-happy-world.tistory.com/44
    //알맞는 퍼즐을 맞추면 퍼즐칸의 색깔이 하얗게 변하며 퍼즐은 더는 움직이지 않는다.
    //퍼즐을 맞추기 전에 모든 퍼즐칸은 하얗다.
    //잘못된 퍼즐을 맞추면 칸의 색은 그대로 검다.
}
