using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState((GameState.currDirection));
    }
    
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.currDirection:
                break;
            case GameState.isFalling:
                break;
            case GameState.isSworded:
                break;
            case GameState.isBurninating:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        currDirection,
        isFalling,
        isSworded,
        isBurninating
    }
}
