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

    public GameObject targetLocation;
    public float distanceToTargetLocation;
    public float correctMargin = 50;
    public Vector2 startPos;

    [Header("Audio")]
    AudioSource source;
    public AudioClip[] putDown;

    PhotoAlbum _pa;
    ChangeColor _cc;

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

    private void Awake()
    {
        //startPos = this.transform.position;
    }

    public void Start()
    {
        source = GetComponent<AudioSource>();
        piece_no = gameObject.name[gameObject.name.Length - 1] - '0';
        _cc = FindObjectOfType<ChangeColor>();
        _pa = FindObjectOfType<PhotoAlbum>();
        startPos = this.transform.position;
        correctMargin = 50;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        source.Play();
    }

    public void setPosition()
    {
        startPos = this.transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    private void Update()
    {
        distanceToTargetLocation = Vector2.Distance(transform.position, targetLocation.transform.position);
    }

    public AudioClip GetPutDownClip()
    {
        return putDown[Random.Range(0, putDown.Length)];
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        source.clip = GetPutDownClip();
        source.Play();

        if (distanceToTargetLocation < correctMargin)
        {
            print("good job");
            _pa.Score();
            this.transform.position = targetLocation.transform.position;
        }
        else
        {
            print("bad job");
            this.transform.position = startPos;
        }

    }

    //https://miniGame3-happy-world.tistory.com/44
}
