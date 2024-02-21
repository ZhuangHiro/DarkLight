using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillItemIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    CanvasGroup _canvasGroup;//定义一个CanvasGroup的引用变量
    Transform _selfParent;
    private int skillId;

    void Awake()
    {
        _selfParent = transform.parent;
        _canvasGroup = transform.GetComponent<CanvasGroup>();//获取Item上的CanvasGroup组件
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        skillId = transform.parent.GetComponent<SkillItem>().id;
        GameObject newicon = GameObject.Instantiate(this.gameObject);
        newicon.transform.SetParent(transform.parent);
        newicon.transform.localPosition =new Vector3(-70,0,0);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.parent = transform.root;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (eventData.pointerEnter.tag == "ShortCut") {
            eventData.pointerEnter.gameObject.GetComponent<ShortCutGrid>().SetSkill(skillId);
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void Start()
    {
      
    }
}
