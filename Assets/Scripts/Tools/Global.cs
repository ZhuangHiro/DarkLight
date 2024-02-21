using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global
{
    private static Global instance = null;
    private Global()
    {
        Init();
    }

    public static Global Instance()
    {
        if (instance == null)
        {
            instance = new Global();
        }
        return instance;
    }
    public bool PauseGame;

    // 玩家持有的星星数
    public int star_count = 100;
    // 玩家持有的钥匙数
    public int keys_count = 100;
    // 玩家持有的皮肤
    public int[] skins = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};


    public void Init()
    {
        star_count = 1000;
        keys_count = 1000;
    }

    public void FirstInit()
    {
        star_count = 1000;
        keys_count = 1000;
    }


    void Update()
    {

    }

    public void SetPauseState(bool isTrue)
    {
        PauseGame = isTrue;
    }
}
