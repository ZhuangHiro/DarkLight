using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ShortCutType
{
    Skill,
    Drug,
    None
}

public class ShortCutGrid : MonoBehaviour {

    public static ShortCutGrid _instance;

    public KeyCode keyCode;

    private ShortCutType type = ShortCutType.None;
    private int id;
    private SkillInfo info;

    private Image icon;

    void Awake()
    {
        _instance = this;
        icon = transform.Find("icon").GetComponent<Image>();
        icon.gameObject.SetActive(false);
;    }

    public void SetSkill(int id)
    {
        this.id = id;
        this.info = SkillsInfo._instance.GetSkillinfoById(id);
        icon.gameObject.SetActive(true);
        icon.sprite = Resources.Load<Sprite>(info.icon_name);
        type = ShortCutType.Skill;
    }
}
