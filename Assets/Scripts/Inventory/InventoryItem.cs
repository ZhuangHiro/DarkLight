using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler//继承能够实现拖拽的接口
{
    CanvasGroup _canvasGroup;//定义一个CanvasGroup的引用变量
    Transform _selfParent;//这个用来保存当前的父对象
    private Image image;
    public static Action<Transform> OnEnter;
    public static Action<Transform> OnExit;
    int id;
    private bool inhover=false;

    void Awake()

    {
        _canvasGroup = transform.GetComponent<CanvasGroup>();//获取Item上的CanvasGroup组件
        image = GetComponent<Image>();
    }

    void Update()
    {
        if(inhover)
        if (Input.GetMouseButtonDown(1))
        {//实现穿戴功能
                InventoryDes._instance.gameObject.SetActive(false);
                bool success = Equipment._instance.Dress(id);
            print(id);
            if (success)
            {
                transform.parent.GetComponent<InventoryItemGird>().MinusNumber();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)//当开始拖动时调用该方法,且只调用一次
    {
        _selfParent = transform.parent;//记录下当前对象的父物体
        _canvasGroup.blocksRaycasts = false;//使射线能够穿过鼠标拖拽的物体
        /*transform.SetParent(m_BagPageMgr.Instance.getPanle.transform);*///当鼠标开始拖拽时,将其父物体设置为Panle,使其能够显示在在所有的游戏对象上面
    }

    public void OnDrag(PointerEventData eventData)//当鼠标正在拖动时调用,在这期间该方法一直调用
    {
        transform.position = eventData.position;//使鼠标拖拽的物体的位置等于鼠标的位置
    }

    public void OnEndDrag(PointerEventData eventData)//当鼠标拖拽完成,松开鼠标时执行该方法,且只执行一次
    {
        GameObject pointobj = eventData.pointerEnter;//获取鼠标拖拽的物体下面的游戏对象
        if (pointobj == null)//当该游戏对象为空时
        {
            transform.SetParent(_selfParent);//将其返回至原来的位置,也就是将其父对象设置成初始的父对象
            transform.localPosition = Vector3.zero;//坐标归零
        }
        else if (pointobj.tag == "Bag")//当射线检测到的是BackGround时
        {
            transform.SetParent(m_BagPageMgr.Instance.getBG.transform);//将其父物体设置为BackGround
            transform.localPosition = Vector3.zero;//坐标归零
        }
        else if (pointobj.tag == "InventoryItemGird")//当射线检测到的是格子的时候
        {
            InventoryItemGird oldParent = _selfParent.GetComponent<InventoryItemGird>();//旧位
            InventoryItemGird newParent = pointobj.transform.GetComponent<InventoryItemGird>();//新位
            transform.SetParent(pointobj.transform);//将该物体的父物体设置为检测到的物体
            transform.localPosition = Vector3.zero;//坐标归零
            newParent.SetId(oldParent.id, oldParent.num);
            oldParent.ClearInfo();
        }
        else if (pointobj.tag == "InventoryItem")//当射线检测到的是Item时,交换两个的父物体
        {
            InventoryItemGird grid1 = _selfParent.GetComponent<InventoryItemGird>();//旧位
            InventoryItemGird grid2 = pointobj.transform.parent.GetComponent<InventoryItemGird>();//新位
            int id = grid1.id;int num = grid1.num;
            Debug.Log(id + "," + num);
            Debug.Log(grid2.id + "," + grid2.num);
            grid1.SetId(grid2.id, grid2.num);
            grid2.SetId(id, num);
            transform.SetParent(pointobj.transform.parent);
            transform.localPosition = Vector3.zero;//坐标归零
            pointobj.transform.SetParent(_selfParent);
            pointobj.transform.localPosition = Vector3.zero;//坐标归零

        }
        else//以上都不满足时,这是我们并不期望的一个结果,所以返回初始的父对象
        {
            transform.SetParent(_selfParent);
            transform.localPosition = Vector3.zero;
        }

        _canvasGroup.blocksRaycasts = true;//使射线不能穿过Item,也就是不能检测到Item下面的物体

    }
    public void SetId(int id)
    {
        ObjectsInfo.ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        image.sprite = Resources.Load<Sprite>(info.icon_name);
    }
    public void SetIconName(int id,string icon_name)
    {
        this.id = id;
        image.sprite = Resources.Load<Sprite>(icon_name);
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
            inhover = true;
        if (eventData.pointerEnter.tag == "InventoryItem")
        {
            InventoryDes._instance.Show(id);

        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        inhover = false;
        if (eventData.pointerEnter.tag == "InventoryItem")
        {
            InventoryDes._instance.gameObject.SetActive(false);
        }
    
    }
}
