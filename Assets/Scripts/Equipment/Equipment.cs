using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Equipment : MonoBehaviour {

    public static Equipment _instance;
    private DOTweenAnimation tween;
    private bool isShow = false;
    private GameObject headgear;
    private GameObject armor;
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject shoe;
    private GameObject accessory;

    private PlayerStatus ps;

    public GameObject EquipmentItem;

    private int attack=0;
    private int def=0;
    private int speed=0;

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<DOTweenAnimation>();

        headgear = transform.Find("Headgear").gameObject;
        armor = transform.Find("Armor").gameObject;
        rightHand = transform.Find("RightHand").gameObject;
        leftHand = transform.Find("LeftHand").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        accessory = transform.Find("Accessory").gameObject;
        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent< PlayerStatus > ();
    }

    public void TransformState()
    {
        if (isShow == false)
        {
            tween.DOPlayForward();
            isShow = true;
        }
        else
        {
            tween.DOPlayBackwards();
            isShow = false;
        }
    }

    public bool Dress(int id)
    {
        ObjectsInfo.ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        //print(id);
        if (info.type != ObjectsInfo.ObjectType.Equip)
        {
            return false;//穿戴不成功
        }
        if (ps.heroType == HeroType.Magician)
        {
            if (info.applicationType == ObjectsInfo.ApplicationType.Swordman)
            {
                return false;//穿戴不成功
            }
        }
        if (ps.heroType == HeroType.Swordman)
        {
            if (info.applicationType == ObjectsInfo.ApplicationType.Magician)
            {
                return false;//穿戴不成功
            }
        }

        GameObject parent = null;
        switch (info.dressType)
        {
            case ObjectsInfo.DressType.Headgear:
                parent = headgear;
                break;
            case ObjectsInfo.DressType.Armor:
                parent = armor;
                break;
            case ObjectsInfo.DressType.RightHand:
                parent = rightHand;
                break;
            case ObjectsInfo.DressType.LeftHand:
                parent = leftHand;
                break;
            case ObjectsInfo.DressType.Shoe:
                parent = shoe;
                break;
            case ObjectsInfo.DressType.Accessory:
                parent = accessory;
                break;
        }

        EquipmentItem item = parent.GetComponentInChildren<EquipmentItem>();
        if (item != null)
        {//说明已经穿戴了同种类型的装备
            Inventory._instance.GetId(item.id);//把已经穿戴的放回背包
            item.SetInfo(info);
        }
        else if(item == null)
        {//没有穿戴同样类型的装备
            GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/EquipmentItem");
            GameObject itemGo = GameObject.Instantiate(itemPrefab);//实例化
            itemGo.transform.SetParent(parent.transform);//设置父物体
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.GetComponent<EquipmentItem>().SetInfo(info);
        }
        UpdateProperty();
        return true;
    }

    public void TakeOff(int id,GameObject go)
    {
        Inventory._instance.GetId(id);
        GameObject.Destroy(go);
        UpdateProperty();
    }

    void UpdateProperty()
    {
        this.attack = 0;
        this.def = 0;
        this.speed = 0;

        EquipmentItem headgearItem = headgear.GetComponentInChildren<EquipmentItem>();
        PlusProperty(headgearItem);
        EquipmentItem armorItem = armor.GetComponentInChildren<EquipmentItem>();
        PlusProperty(armorItem);
        EquipmentItem leftHandItem = leftHand.GetComponentInChildren<EquipmentItem>();
        PlusProperty(leftHandItem);
        EquipmentItem rightHandItem = rightHand.GetComponentInChildren<EquipmentItem>();
        PlusProperty(rightHandItem);
        EquipmentItem shoeItem = shoe.GetComponentInChildren<EquipmentItem>();
        PlusProperty(shoeItem);
        EquipmentItem accessoryItem = accessory.GetComponentInChildren<EquipmentItem>();
        PlusProperty(accessoryItem);
    }

    void PlusProperty(EquipmentItem item)
    {
        if (item != null)
        {
            ObjectsInfo.ObjectInfo equipInfo = ObjectsInfo._instance.GetObjectInfoById(item.id);
            this.attack += equipInfo.attack;
            this.def += equipInfo.def;
            this.speed += equipInfo.speed;
        }
    }

}
