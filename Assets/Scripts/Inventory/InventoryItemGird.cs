using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemGird : MonoBehaviour {

    public int id = 0;
    private ObjectsInfo.ObjectInfo info = null;
    public int num = 0;//物品数量
    private Text numLabel;
    public InventoryItem InventoryItem;
	void Start () {
        numLabel.gameObject.SetActive(false);
	}
    void Awake()
    {
        numLabel = this.GetComponentInChildren<Text>(); 
    }

    void Update () {
        
	}

    public void SetId(int id,int num=1)
    {
        this.id = id;
         info = ObjectsInfo._instance.GetObjectInfoById(id);
        InventoryItem item = this.GetComponentInChildren<InventoryItem>();
        item.SetIconName(id,info.icon_name);
        numLabel.gameObject.SetActive(true);
        this.num = num;
        numLabel.text = num.ToString();
    }

    public void PlusNumber(int num = 1)
    {
        this.num += num;
        numLabel.text = this.num.ToString();
    }

    //用来减去数量的，可以用于装备穿戴
    public bool MinusNumber(int num = 1)
    {
        if (this.num >= num)
        {
            this.num -= num;
            numLabel.text = this.num.ToString();
            if (this.num == 0)
            {//清空格子
                ClearInfo();//清空储存信息
                GameObject.Destroy(GetComponentInChildren<InventoryItem>().gameObject);//消除物品
            }
            return true;
        }
        return false;
    }

    public void ClearInfo()
    {
        id = 0;
        info = null;
        num = 0;
        numLabel.gameObject.SetActive(false) ;
    }
    public void UpdateNumDisplay()
    {
        numLabel.gameObject.SetActive(true);
        numLabel.text = num.ToString();
    }
    public void UpdateNumHide()
    {
        numLabel.gameObject.SetActive(false);
        num = 0;
        numLabel.text = num.ToString();
    }
}
