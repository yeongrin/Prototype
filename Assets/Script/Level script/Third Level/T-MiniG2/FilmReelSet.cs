using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FilmReelSet : MonoBehaviour
{
    PuzzleGame2 _pg2;

    private void Start()
    {
        _pg2 = FindObjectOfType<PuzzleGame2>();
    }
    public void SetPositions()
    {
        _pg2.setPosition();
    }
}
