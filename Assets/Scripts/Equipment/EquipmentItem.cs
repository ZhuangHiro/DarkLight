using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int id;
    private Image image;
    private bool isHover = false;

    void Awake()
    {
        image =this.GetComponent<Image>();
    }

    void Update()
    {
        if (isHover)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Equipment._instance.TakeOff(id, this.gameObject);
            }
        }
    }

    public void SetId(int id)
    {
        this.id = id;
        ObjectsInfo.ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        SetInfo(info);
    }

    public void SetInfo(ObjectsInfo.ObjectInfo info)
    {
        this.id = info.id;
        image.sprite = Resources.Load<Sprite>(info.icon_name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
    }
}
