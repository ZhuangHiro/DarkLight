﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInfo : MonoBehaviour {
    public static ObjectsInfo _instance;

    private Dictionary<int, ObjectInfo> objectInfoDict = new Dictionary<int, ObjectInfo>();//建立字典

    public TextAsset objectInfoLiatText;

    void Awake()
    {
        _instance = this;
        ReadInfo();
    }

    public ObjectInfo GetObjectInfoById(int id)
    {
        ObjectInfo info = null;

        objectInfoDict.TryGetValue(id, out info);

        return info;
    }

    void ReadInfo()
    {
        string text = objectInfoLiatText.text;
        string[] strArray = text.Split('\n'); 

        foreach(string str in strArray)
        {
            string[] proArray = str.Split(',');
            ObjectInfo info = new ObjectInfo();

            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            ObjectType type = ObjectType.Drug;
            switch (str_type)
            {
                case "Drug":
                    type = ObjectType.Drug;
                    break;
                case "Equip":
                    type = ObjectType.Equip;
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;
            }
            info.id = id;
            info.name = name;
            info.icon_name = icon_name;
            info.type = type;
            if(type == ObjectType.Drug)
            {
                int hp = int.Parse(proArray[4]);
                int mp = int.Parse(proArray[5]);
                int price_sell = int.Parse(proArray[6]);
                int price_buy = int.Parse(proArray[7]);
                info.hp = hp;
                info.mp = mp;
                info.price_sell = price_sell;
                info.price_buy = price_buy;
            }else if (type==ObjectType.Equip)
            {
                info.attack = int.Parse(proArray[4]);
                info.def = int.Parse(proArray[5]);
                info.speed = int.Parse(proArray[6]);
                info.price_sell = int.Parse(proArray[9]);
                info.price_buy = int.Parse(proArray[10]);
                string str_dresstype = proArray[7];
                switch (str_dresstype)
                {
                    case "Headgear":
                        info.dressType = DressType.Headgear;
                        break;
                    case "Armor":
                        info.dressType = DressType.Armor;
                        break;
                    case "RightHand":
                        info.dressType = DressType.RightHand;
                        break;
                    case "LeftHand":
                        info.dressType = DressType.LeftHand;
                        break;
                    case "Shoe":
                        info.dressType = DressType.Shoe;
                        break;
                    case "Accessory":
                        info.dressType = DressType.Accessory;
                        break;
                }
                string str_appType = proArray[8];
                switch (str_appType)
                {
                    case "Swordman":
                        info.applicationType = ApplicationType.Swordman;
                        break;
                    case "Magician":
                        info.applicationType = ApplicationType.Magician;
                        break;
                    case "Common":
                        info.applicationType = ApplicationType.Common;
                        break;
                }
            }

            objectInfoDict.Add(id, info);//添加到字典中，id为key,可以很方便的根据id查找到这个物品
        }
    }

    //id
    //名称
    //icon名称
    //类型（药品Drug）
    //加血量值
    //加魔法值
    //出售价
    //购买价


    public enum ObjectType
    {
        Drug,//药品
        Equip,//装备
        Mat//材料
    }

    public enum DressType
    {
        Headgear,
        Armor,
        RightHand,
        LeftHand,
        Shoe,
        Accessory
    }

    public enum ApplicationType
    {
        Swordman,//剑士
        Magician,//魔法师
        Common//通用
    }

    public class ObjectInfo
    {
        public int id;
        public string name;
        public string icon_name;
        public ObjectType type;
        public int hp;
        public int mp;
        public int price_sell;
        public int price_buy;

        public int attack;
        public int def;
        public int speed;
        public DressType dressType;//穿戴类型
        public ApplicationType applicationType;//适用类型
    }
}
