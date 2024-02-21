using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Runtime.Serialization;

public class Inventory : MonoBehaviour {

    public static Inventory _instance;
    public DOTweenAnimation tween;
    private int coinCount = 1000;

    public List<InventoryItemGird> itemGridList = new List<InventoryItemGird>();
    public Text coinNumberLabel;
    public GameObject InventoryItem;//动态预制体
	// Use this for initialization

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<DOTweenAnimation>();
    }



	void Start () {
        tween.DOPause();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetId(Random.Range(2001, 2023));
        }
	}
    
    //拾取到id的物品，并添加到物品栏里面
    //处理拾取物品的功能
    public void GetId(int id,int count=1)
    {
        //第一步是查找在所有的物品中是否存在该物品
        //第二如果存在，让num+1
        //第三如果不存在，查找空的方格，然后把新创建的InventoryItem放在这个空的方格
        InventoryItemGird grid = null;
        for (int i = 0; i < itemGridList.Count; i++)
        {
            if (itemGridList[i].id == id)
            {
                grid = itemGridList[i];
                break;
            }
        }
        if (grid != null)
        {//存在的情况
            grid.PlusNumber(count);
        }
        else
        {//不存在的情况
            for (int j = 0; j < itemGridList.Count; j++)
            {
                if (itemGridList[j].id == 0)
                {
                    grid = itemGridList[j];
                    CreatNewItem(id, grid,count);
                    break;
                }
            }
        }
    }
    public void CreatNewItem(int id, InventoryItemGird parentGrid, int num = 1)
    {
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Inventory-item");//加载动态预制体
        GameObject itemGo = GameObject.Instantiate(itemPrefab);//实例化
        itemGo.transform.SetParent(parentGrid.transform);//设置子物体
        itemGo.transform.localPosition = Vector3.zero;
        itemGo.transform.localScale = Vector3.one;
        parentGrid.SetId(id,num);
        Debug.Log("创建的物品id为"+id);
    }

    private bool isShow = false;
    void Show()
    {
        isShow = true;
        tween.DOPlayForward();
    }

    void Hide()
    {
        isShow = false;
        tween.DOPlayBackwards();
    }
    public void TransformState()
    {
        if (isShow == false)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public bool GetCoin(int count)
    {
        if (coinCount >= count)
        {
            coinCount -= count;
            coinNumberLabel.text = coinCount.ToString();
            return true;
        }
        return false;
    }
}
