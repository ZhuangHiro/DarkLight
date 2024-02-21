using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadLevelManager;
//using MadLevelManager;
using UnityEngine;

public class MadlevelOption
{
    private static MadlevelOption instance = null;

    private MadlevelOption()
    {
    }
    public static MadlevelOption GetInstance()
    {
        if (instance == null)
        {
            instance = new MadlevelOption();
        }

        return instance;
    }

    public void OnSpriteClick(MadSprite sprite, Action action)
    {
        sprite.onMouseUp = sprite.onTap = (s) =>
        {
            MadDebug.Log(sprite.name + ":click");
            action();
        };
    }

    public void LevelMaxComplete()
    {
        MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, StringUtils.Star_1, true);
        MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, StringUtils.Star_2, true);
        MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, StringUtils.Star_3, true);
        MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
        // MadLevel.LoadNext();
    }

    public void LevelComplete()
    {

        //        float score = TimerCountDown.Instance.GetTimePersent();
        //
        //        Debug.Log("score:" + score);
        //
        //        if (score >= 0f)
        //        {
        //            MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, StringUtils.Star_1, true);
        //            MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
        //        }
        //
        //        if (score >= 0.4f)
        //        {
        //            MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, StringUtils.Star_2, true);
        //            MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
        //        }
        //
        //        if (score >= 0.8f)
        //        {
        //            MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, StringUtils.Star_3, true);
        //            MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
        //        }
        //        Complete();
    }

    private void Complete()
    {
        if (MadLevel.HasNext(MadLevel.Type.Level))
        {
            MadLevel.LoadNext(MadLevel.Type.Level);
        }
        else
        {
            MadLevel.LoadLevelByName(StringUtils.SelectScene);
        }

    }

}
