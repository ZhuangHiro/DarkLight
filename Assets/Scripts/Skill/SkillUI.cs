using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillUI : MonoBehaviour {

    public static SkillUI _instance;
    private DOTweenAnimation tween;
    private bool isShow = false;
    private PlayerStatus ps;

    public GameObject grid;
    public int[] magicianSkillIdList;
    public int[] swordmanSkillIdList;

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<DOTweenAnimation>();
    }

    void Start()
    {
        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
        int[] idList = null;
        switch (ps.heroType)
        {
            case HeroType.Magician:
                idList = magicianSkillIdList;
                break;
            case HeroType.Swordman:
                idList = swordmanSkillIdList;
                break;
        }
        foreach(int id in idList)
        {
            GameObject skillItemPrefab = Resources.Load<GameObject>("Prefabs/SkillItem");//加载动态预制体
            GameObject itemGo = GameObject.Instantiate(skillItemPrefab);//实例化
            itemGo.transform.SetParent(grid.transform);//设置子物体
            skillItemPrefab.GetComponent<SkillItem>().SetId(id);
        }
    }

    public void TransformState()
    {
        if (isShow)
        {
            tween.DOPlayBackwards();
            isShow = false;
            
        }
        else
        {
            tween.DOPlayForward();
            isShow = true;
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        SkillItem[] items = transform.Find("Scroll View/Viewport/Content").GetComponentsInChildren<SkillItem>();
        foreach(SkillItem item in items)
        {
            item.UpdateShow(ps.Level);
        }
    }
}
