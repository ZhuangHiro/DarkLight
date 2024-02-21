using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ScrollView中Grid添加Button导致无法拖拽的BUG。解决方法：（1）自己定义委托（2）委托加入到监听按钮中。实现监听方法。
/// </summary>
public class GridItemClick : MonoBehaviour, IPointerClickHandler
{

    public Action OnItemClickAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnItemClickAction != null)
        {
            OnItemClickAction();
        }
    }
}

