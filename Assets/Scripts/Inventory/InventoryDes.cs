using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDes : MonoBehaviour {

    public static InventoryDes _instance;
    public Text text;
    private int id;
    //private float timer = 0;

    void Awake()
    {
        _instance = this;
        text = this.GetComponentInChildren<Text>();
        this.gameObject.SetActive(false);
    }
    void Start () {
		
	}
	
	void Update () {
        //if (this.gameObject.activeInHierarchy == false)
        //{
        //    timer -= Time.deltaTime;
        //    if (timer <= 0)
        //    {
        //        this.gameObject.SetActive(false);
        //    }
        //}
        Vector2 position = Input.mousePosition;
        transform.localPosition = position;
    }

    public void Show(int id)
    {
        this.gameObject.SetActive(true);//timer = 0.1f;
        //transform.localPosition = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        //transform.localPosition = transform.TransformPoint(Input.mousePosition);
        this.id = id;
        ObjectsInfo.ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        string des = "";
        switch (info.type)
        {
            case ObjectsInfo.ObjectType.Drug:
                des = GetDrugDes(info);
                break;
            case ObjectsInfo.ObjectType.Equip:
                des = GetEquipDes(info);
                break;
        }
        text.text = des;
    }

    string GetDrugDes(ObjectsInfo.ObjectInfo info)
    {
        string str = "";
        str += "名称：" + info.name + "\n";
        str += "+HP：" + info.hp + "\n";
        str += "+MP：" + info.mp + "\n";
        str += "出售价：" + info.price_sell + "\n";
        str += "购买价：" + info.price_buy + "\n";

        return str;
    }
    string GetEquipDes(ObjectsInfo.ObjectInfo info)
    {
        string str = "";
        str += "名称：" + info.name + "\n";
        switch (info.dressType)
        {
            case ObjectsInfo.DressType.Headgear:
                str += "穿戴类型：头盔\n";
                break;
            case ObjectsInfo.DressType.Armor:
                str += "穿戴类型：盔甲\n";
                break;
            case ObjectsInfo.DressType.LeftHand:
                str += "穿戴类型：左手\n";
                break;
            case ObjectsInfo.DressType.RightHand:
                str += "穿戴类型：右手\n";
                break;
            case ObjectsInfo.DressType.Shoe:
                str += "穿戴类型：鞋\n";
                break;
            case ObjectsInfo.DressType.Accessory:
                str += "穿戴类型：饰品\n";
                break;
        }
        switch (info.applicationType)
        {
            case ObjectsInfo.ApplicationType.Swordman:
                str += "适用类型：剑士\n";
                break;
            case ObjectsInfo.ApplicationType.Magician:
                str += "适用类型：魔法师\n";
                break;
            case ObjectsInfo.ApplicationType.Common:
                str += "适用类型：通用\n";
                break;
        }
        str += "攻击力：" + info.attack + "\n";
        str += "防御力：" + info.def + "\n";
        str += "速度：" + info.speed + "\n";

        str += "出售价：" + info.price_sell + "\n";
        str += "购买价：" + info.price_buy + "\n";

        return str;
    }
}
