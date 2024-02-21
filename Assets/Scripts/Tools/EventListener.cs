using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public enum E_TouchType : byte
{
    OnClick,
    OnDoubleClick,
    OnDown,
    OnUp,
    OnEnter,
    OnExit,
    OnSelect,
    OnUpdateSelect,
    OnDeSelect,
    OnDrag,
    OnDragEnd,
    OnDrop,
    OnScroll,
    OnMove,
}

public delegate void OnTouchHandle(GameObject target, object eventData, params object[] _params);

public class TouchHandle
{
    public E_TouchType TouchType;

    private event OnTouchHandle eventHandle = null;

    private object[] handleParams;

    public TouchHandle(OnTouchHandle _handle, params object[] _params)
    {
        SetHandle(_handle, _params);
    }

    public TouchHandle()
    {

    }

    public void SetHandle(OnTouchHandle _handle, params object[] _params)
    {
        DestoryHandle();
        eventHandle += _handle;
        handleParams = _params;
    }

    public void CallEventHandle(GameObject _lsitener, object _args)
    {
        if (null != eventHandle)
        {
            eventHandle(_lsitener, _args, handleParams);
        }
    }


    public void DestoryHandle()
    {
        if (null != eventHandle)
        {
            eventHandle -= eventHandle;
            eventHandle = null;
        }
    }

}

public class EventListener : MonoBehaviour,
#region interface
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler,

    ISelectHandler,
    IUpdateSelectedHandler,
    IDeselectHandler,

    IDragHandler,
    IEndDragHandler,
    IDropHandler,
    IScrollHandler,
    IMoveHandler
#endregion
{
    public Dictionary<E_TouchType, TouchHandle> dicHandles = new Dictionary<E_TouchType, TouchHandle>();

    /// <summary>
    /// Get the specified go.
    /// </summary>
    /// <param name="go">Go.</param>
    static public EventListener Get(GameObject go)
    {
        return go.GetOrAddCompoment<EventListener>();

    }

    static public EventListener Get(Transform tran)
    {
        return tran.GetOrAddCompoment<EventListener>();
    }

    static public EventListener Get(Button btn)
    {
        return btn.gameObject.GetOrAddCompoment<EventListener>();
    }

    void OnDestory()
    {
        this.RemoveAllHandle();
    }

    private void RemoveAllHandle()
    {
        foreach (var item in dicHandles)
        {
            item.Value.DestoryHandle();
        }
        dicHandles.Clear();
    }

    #region Handler implementation

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDrag);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDragEnd);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IDropHandler implementation

    public void OnDrop(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDrop);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnClick);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerDownHandler implementation

    public void OnPointerDown(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDown);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerUpHandler implementation

    public void OnPointerUp(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnUp);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }
    #endregion

    #region IPointerEnterHandler implementation

    public void OnPointerEnter(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnEnter);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnExit);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region ISelectHandler implementation

    public void OnSelect(BaseEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnSelect);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IUpdateSelectedHandler implementation

    public void OnUpdateSelected(BaseEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnUpdateSelect);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IDeselectHandler implementation

    public void OnDeselect(BaseEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDeSelect);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IScrollHandler implementation

    public void OnScroll(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnScroll);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IMoveHandler implementation

    public void OnMove(AxisEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnMove);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #endregion

    public TouchHandle GetHandle(E_TouchType type)
    {
        TouchHandle handle;
        if (dicHandles.TryGetValue(type, out handle))
        {
            return handle;
        }
        return null;
    }

    public void SetEventListener(E_TouchType _type, OnTouchHandle _handle, params object[] _params)
    {
        TouchHandle handle = GetHandle(_type);
        if (handle == null)
        {
            handle = new TouchHandle();
            dicHandles.Add(_type, handle);
        }
        dicHandles[_type].TouchType = _type;
        dicHandles[_type].SetHandle(_handle, _params);
    }

    public void RemoveEventListener(E_TouchType _type)
    {
        TouchHandle handle = GetHandle(_type);
        if (handle == null)
            return;

        dicHandles[_type].DestoryHandle();
        dicHandles.Remove(_type);
    }
}

