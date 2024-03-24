using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Title, Playing, Paused, GameOver }

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public int score = 0;
    int scoreMultiplier = 1;


    void Start()
    {

    }
}
