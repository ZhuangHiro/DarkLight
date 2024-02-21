using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// content赋值为knob的物体。
/// </summary>
public class ScrollCircle : ScrollRect
{
    // 摇杆输出的方向向量
    private Vector2 m_ForceVector;
    // 摇杆半径
    protected float m_Radius;

    public Vector2 ForceVector
    {
        get { return m_ForceVector; }
        private set { }
    }


    protected override void Start()
    {
        base.Start();
        m_ForceVector = Vector2.zero;
        // mRadius = (transform as RectTransform).sizeDelta.x * 0.5f; // 计算摇杆块的半径
        m_Radius = 150f;
    }

    public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnDrag(eventData);
        var contentPostion = this.content.anchoredPosition;
        if (contentPostion.magnitude > m_Radius)
        {
            contentPostion = contentPostion.normalized * m_Radius;
            SetContentAnchoredPosition(contentPostion);
        }
        m_ForceVector = contentPostion.normalized;
        //Debug.Log("方向向量->" + m_ForceVector);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        //base.OnEndDrag(eventData);
        m_ForceVector = Vector2.zero;
        SetContentAnchoredPosition(Vector2.zero);
        //Debug.Log("方向向量->" + m_ForceVector);
    }
}