using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Status : MonoBehaviour {

    public static Status _instance;
    private DOTweenAnimation tween;
    private bool isShow = false;

    private Text attackLabel;
    private Text defLabel;
    private Text speedLabel;
    private Text pointRemainLabel;
    private Text summaryLabel;

    private GameObject attackButtonGo;
    private GameObject defButtonGo;
    private GameObject speedButtonGo;

    private PlayerStatus playerStatus;

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<DOTweenAnimation>();

        attackLabel = transform.Find("attack").GetComponent<Text>();
        defLabel = transform.Find("def").GetComponent<Text>();
        speedLabel = transform.Find("speed").GetComponent<Text>();
        pointRemainLabel = transform.Find("point_remain").GetComponent<Text>();
        summaryLabel = transform.Find("summary").GetComponent<Text>();
        attackButtonGo = transform.Find("attack_plusbutton").gameObject;
        defButtonGo = transform.Find("def_plusbutton").gameObject;
        speedButtonGo = transform.Find("speed_plusbutton").gameObject;

        playerStatus = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    void Start () {
        tween.DOPause();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void TransformState()
    {
        if (isShow == false)
        {
            UpdateShow();
            tween.DOPlayForward();isShow = true;
        }
        else
        {
            tween.DOPlayBackwards();isShow = false;
        }
    }
    void UpdateShow()
    {
        attackLabel.text = playerStatus.attack +"+"+ playerStatus.attack_plus;
        defLabel.text = playerStatus.def + "+" + playerStatus.def_plus;
        speedLabel.text = playerStatus.speed + "+" + playerStatus.speed_plus;
        pointRemainLabel.text = playerStatus.point_remain.ToString();
        summaryLabel.text = "伤害：" + (playerStatus.attack + playerStatus.attack_plus)+" "
            + "防御：" + (playerStatus.def + playerStatus.def_plus) + " "
            + "速度：" + (playerStatus.speed + playerStatus.speed_plus);

        if (playerStatus.point_remain > 0)
        {
            attackButtonGo.SetActive(true);
            defButtonGo.SetActive(true);
            speedButtonGo.SetActive(true);
        }
        else
        {
            attackButtonGo.SetActive(false);
            defButtonGo.SetActive(false);
            speedButtonGo.SetActive(false);
        }
    }

    public void OnAttackPlusClick()
    {
        bool  success = playerStatus.GetPoint();
        if (success)
        {
            playerStatus.attack_plus++;
            UpdateShow();
        }
    }
    public void OnDefPlusClick()
    {
        bool success = playerStatus.GetPoint();
        if (success)
        {
            playerStatus.def_plus++;
            UpdateShow();
        }
    }
    public void OnSpeedPlusClick()
    {
        bool success = playerStatus.GetPoint();
        if (success)
        {
            playerStatus.speed_plus++;
            UpdateShow();
        }
    }
}
