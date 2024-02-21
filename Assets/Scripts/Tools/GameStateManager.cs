using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Load,      //准备
    Playing,   //玩
    Win,       //胜利
    TypeError,//颜色错误
    CountError   //数目错误
}

public class GameStateManager : MonoBehaviour
{
    public GameState current_state = GameState.Load;

    private static GameStateManager _instance = null;

    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameStateManager is null...");
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
