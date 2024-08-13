using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleEmpty2 : MonoBehaviour
{
    private List<Transform> pieces;
    private Vector2Int dimensions;
    private float width = 0.15f;
    private float height = 0.15f;

    private Transform draggingPiece = null;
    private Vector3 offset;

    private int piecesCorrect;

    [Header ("UI Elements")]
    [SerializeField]
    private int difficulty = 1;
    private List<Texture2D> imageTextures;
    public Transform gameHolder;
    public Transform piecePrefab;

    public Transform levelSelectPrefab;
    public Image levelSelectPanel;

    void Start()
    {
      /*  foreach (Texture2D texture in imageTextures)
        {
            Image image = Instantiate(levelSelectPrefab, levelSelectPanel);
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            image.GetComponent<Button>().onClick.AddListener(delegate { StartGame(texture); });
        }*/
        
    }

   /*public void StartGame(Texture2D puzzleTexture)
    {
        levelSelectPanel.processingObject.SetActive(false);

        pieces = new List<Transform>();
        piecesCorrect = 0;
        dimensions = GetDimensions(puzzleTexture, difficulty);

        UpdateBorder();
        CreatePuzzle(puzzleTexture);

    }*/

    Vector2Int GetDimensions(Texture2D puzzleTexture, int difficulty)
    {
        Vector2Int dimensions = Vector2Int.zero;

        if (puzzleTexture.width < puzzleTexture.height)
        {
            dimensions.x = difficulty;
            dimensions.y = (difficulty * puzzleTexture.height) / puzzleTexture.width;
        }
        else
            dimensions.x = (difficulty * puzzleTexture.width) / puzzleTexture.height;
        dimensions.y = difficulty;

        return dimensions;
    }

    void UpdateBorder()
    {
        LineRenderer lineRenderer = gameHolder.GetComponent<LineRenderer>();

        float halfWidth = (width * dimensions.x) / 2f;
        float halfHeight = (height * dimensions.y) / 2f;

       // float borderZ = 0f;

       //lineRenderer.SetPosition(0, new Vector3(-halfWidth, halfHeight, borderZ));
       //lineRenderer.SetPosition(1, new Vector3(halfWidth, halfHeight, borderZ));
       //lineRenderer.SetPosition(2, new Vector3(halfWidth, -halfHeight, borderZ));
       //lineRenderer.SetPosition(3, new Vector3(-halfWidth, -halfHeight, borderZ));

        lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        lineRenderer.enabled = true;
    }

    void CreatePuzzle(Texture2D puzzleTexture)
    {
        height = 1f / dimensions.y;
        float aspect = (float)puzzleTexture.width / puzzleTexture.height;
        width = aspect / dimensions.x;

        for (int row = 0; row < dimensions.y; row++)
        {

            for (int col = 0; col < dimensions.y; col++)
            {

                Transform piece = Instantiate(piecePrefab, gameHolder);
                piece.localPosition = new Vector3((-width * dimensions.x / 2) + (width * col) + (width / 2),
                    (-height * dimensions.y / 2) + (height * row) + (height / 2), -1);
                piece.localScale = new Vector3(width, height, 1f);

                piece.name = $"Piece{(row * dimensions.x) + col}";
                pieces.Add(piece);
            }
           
        }

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
           // Debug.Log("click");

            if (hit)
            {
                draggingPiece = hit.transform;
                offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset += Vector3.back;
                //Debug.Log("click2");
            }
        }

        if( draggingPiece && Input.GetMouseButtonUp(0))
        {
            SnapAndDisableIfCorrect();
            draggingPiece.position += Vector3.forward;
            draggingPiece = null;
            //Debug.Log("click3");
        }

        if(draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = draggingPiece.position.z;
            draggingPiece.position = newPosition;
            //Debug.Log("click4");
        }
    }

    void SnapAndDisableIfCorrect()
    {
        int pieceIndex = pieces.IndexOf(draggingPiece);

        int col = pieceIndex % dimensions.x;
        int row = pieceIndex / dimensions.x;

        Vector2 targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2),
            (-height * dimensions.y / 2) +(height * row) + (height / 2));

        if (Vector2.Distance(draggingPiece.localPosition, targetPosition) < (width / 2))
        {
            draggingPiece.localPosition = targetPosition;

            draggingPiece.GetComponent<BoxCollider2D>().enabled = false;
            piecesCorrect++;
            if(piecesCorrect == pieces.Count)
            {
                Debug.Log("fin");
            }
        }
    }
}
