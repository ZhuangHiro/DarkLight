using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BarNpc : NPC {

    public DOTweenAnimation questTween;

    public bool isInTask = false;//是否在任务中
    public int killCount = 0;//任务进度

    public Text desLabel;
    public GameObject acceptBtnGo;
    public GameObject cancelBtnGo;
    public GameObject okBtnGo;

    private PlayerStatus status;
    private AudioSource audio;

    void Awake()
    {
        audio = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audio.DOPlayForward();
            Invoke("ShowQuest", 0.1f);
            //ShowQuest();
            if (isInTask)
            {
                ShowTaskProgress();
            }
            else
            {
                ShowTaskDes();
            }
        }
    }
    void ShowQuest()
    {
        questTween.gameObject.SetActive(true);
        questTween.DOPlayForward();
    }
    public void OnCloseButtonClick()
    {
        Invoke("HideQuest", 0.1f);
        
    }
    void HideQuest()
    {
        questTween.DOPlayBackwards();
        questTween.gameObject.SetActive(false);
    }

    void ShowTaskDes()//任务描述
    {
        desLabel.text = "任务：\n杀死10只小野狼\n\n奖励：\n1000金币";
        okBtnGo.SetActive(false);
        acceptBtnGo.SetActive(true);
        cancelBtnGo.SetActive(true);
    }
    void ShowTaskProgress()//任务进度
    {
        desLabel.text = "任务：\n你已经杀死" + killCount + "/10只小野狼\n\n奖励：\n1000金币";
        okBtnGo.SetActive(true);
        acceptBtnGo.SetActive(false);
        cancelBtnGo.SetActive(false);
    }
    
    public void OnAcceptButtonClick()
    {
        Invoke("ShowTaskProgress", 0.1f);
        isInTask=true;
    }
    public void OnCancelButtonClick()
    {
        Invoke("HideQuest", 0.1f);
    }
    public void OnOkButtonClick()
    {
        if (killCount >= 10)//完成任务
        {
            status.GetCoint(1000);
            killCount = 0;
            ShowTaskDes();
        }
        else//未完成任务
        {
            Invoke("HideQuest", 0.1f);
        }
    }
}
