using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using DG.Tweening;
using DG.Tweening.Core;

/// <summary>
/// 使用方法。
/// 当前物体挂载此脚本，创建子物体命名为“mask，为Image控件。
/// mask的ImageType设置为Filled填充模式，然后设置填充方向Fill Origin为Top。
/// 取消Clockwise的勾选，取消Raycast Target属性的勾选
/// </summary>
public class SkillCoolingItem : MonoBehaviour
{
    //冷却周期
    public float coolingTimer = 2.0f;

    // 当前计算时间
    private float currentTime = 0.0f;

    //冷却图片，需要为子物体，并且名字为mask
    private Image coolingImage;
    // 是否冷却完成
    private bool isReady;
    // 闪烁变量
    private bool isBlink;
    // 比例限制变量
    private float rate = 0.6f;

    private Tweener blink_tweener;
    private Tweener blink_mask_tweener;

    // 倒计时停止变量
    private bool isStop;

    void Awake()
    {
        coolingImage = transform.GetComponent<Image>("mask");
        isBlink = false;
        blink_tweener = transform.GetComponent<Image>().DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo).SetAutoKill(false).Pause();
        blink_mask_tweener = transform.GetComponent<Image>("mask").DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo).SetAutoKill(false).Pause();
    }

    void Start()
    {
        currentTime = coolingTimer;
        this.OnSkillClick();
    }

    // 技能按键按下，冷却效果，可以独立配合监听。
    public void OnSkillClick()
    {
        isReady = false;

        //Debug.Log("currentTime->" + currentTime);

        currentTime = coolingTimer;

        if (currentTime >= coolingTimer)
        {
            currentTime = 0.0f;

            coolingImage.fillAmount = 1.0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTime < coolingTimer)
        {
            if (isStop) return;

            currentTime += Time.deltaTime;
            //按时间比例计算出Fill Amount值
            coolingImage.fillAmount = 1 - currentTime / coolingTimer;

            if (!isBlink && coolingImage.fillAmount <= rate)
            {
                isBlink = true;
                DoBlink();
            }
        }
        else
        {
            isReady = true;
            gameObject.SetActive(false);
        }
    }
    // 冷却完成的判断值
    public bool SkillReady()
    {
        return isReady;
    }

    private void DoBlink(bool isTrue = true)
    {
        if (isTrue)
        {
            blink_tweener.Restart();
            blink_mask_tweener.Restart();
        }
        else
        {

            blink_tweener.Pause();
            blink_mask_tweener.Pause();
        }
    }

    public void Stop()
    {
        if (coolingImage.fillAmount <= rate)
        {
            transform.GetComponent<Image>().color = new Color(1,1,1,1);
            transform.GetComponent<Image>("mask").color = Color.red;

            DoBlink(false);
        }
        isStop = true;
    }

    public void Restart()
    {
        if (coolingImage.fillAmount <= rate) DoBlink(true);
        isStop = false;
    }
}
