using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public World_1 World1;
    public World_2 World2;
    public World_3 World3;

    public enum GameState
    {
        COVER,
        COVER_TO_S1,
        S1,
        S1_To_S2,
        S2,
        S2_To_S3,
        S3,
        END
    }

    private GameState _gameState = GameState.COVER;

    private void Awake()
    {
        instance = this;
    }

    private void GoNextState()
    {
        ++_gameState;
        Debug.Log(_gameState.ToString());
    }
}