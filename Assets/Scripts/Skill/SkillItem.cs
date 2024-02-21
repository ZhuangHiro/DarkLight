using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillItem : MonoBehaviour {

    public int id;
    private SkillInfo info;
    private Image iconname_sprite;
    private Text name_label;
    private Text applytype_label;
    private Text des_label;
    private Text mp_label;

    private GameObject icon_mask;

    void Awake()
    {
        InitProperty();
    }

    void InitProperty()
    {
        iconname_sprite = transform.Find("icon").GetComponent<Image>();
        name_label = transform.Find("property/name_bg/name").GetComponent<Text>();
        applytype_label = transform.Find("property/applytype_bg/applytype").GetComponent<Text>();
        des_label = transform.Find("property/des_bg/des").GetComponent<Text>();
        mp_label = transform.Find("property/mp_bg/mp").GetComponent<Text>();
        icon_mask = transform.Find("icon_mask").gameObject;
        icon_mask.SetActive(false);
    }

    public void UpdateShow(int levle)
    {
        info = SkillsInfo._instance.GetSkillinfoById(id);
        if (info.level <= levle)
        {//技能可用
            icon_mask.SetActive(false);
        }
        else
        {
            icon_mask.SetActive(true);
        }
    }

    public void SetId(int id)
    {
        InitProperty();//初始化属性
        this.id = id;
        info = SkillsInfo._instance.GetSkillinfoById(id);
        iconname_sprite.sprite = Resources.Load<Sprite>(info.icon_name);
        name_label.text = info.name;
        switch (info.applyType)
        {
            case ApplyType.Passive:
                applytype_label.text = "增益";
                break;
            case ApplyType.Buff:
                applytype_label.text = "增强";
                break;
            case ApplyType.SingleTarget:
                applytype_label.text = "单个目标";
                break;
            case ApplyType.MultiTarget:
                applytype_label.text = "群体技能";
                break;
        }
        des_label.text = info.des;
        mp_label.text = info.mp + "MP";
    }
}
