using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberJump : MonoBehaviour
{
    //声明
    private Sequence mScoreSequence;
    private Text label;

    void Awake()
    {
        //函数内初始化
        mScoreSequence = DOTween.Sequence();
        //函数内设置属性
        mScoreSequence.SetAutoKill(false);

        label = GetComponent<Text>();
    }
    /// <summary>
    /// 数值滚动方法
    /// </summary>
    /// <param name="lastNum">滚动开始数值</param>
    /// <param name="newNum">滚动结束数值</param>
    /// <param name="time">滚动时间，时间越小，滚动越快</param>
    public void UpdateNumText(int lastNum,int newNum, float time)
    {
        mScoreSequence.Append(DOTween.To(delegate (float value) {
            //向下取整
            var temp = Mathf.Floor(value);
            //向Text组件赋值
            label.text = temp + "";
        }, lastNum, newNum, time));
    }

}
