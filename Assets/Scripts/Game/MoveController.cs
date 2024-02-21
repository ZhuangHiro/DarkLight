using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour
{

    private static MoveController _instance;

    public static MoveController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MoveController Instance is null...");
            }

            return _instance;
        }
    }

    private bool isMouseDown;
    private Vector3 lastMousePosition = Vector3.zero;
    private Vector3 tempVector3;

    private float limit_width = 6.5f;
    private float limit_height = 12.0f;

    public Vector2 DeliveryInVec2 { get; set; }
    public Vector2 DeliveryOutVec2 { get; set; }


    // 等待移动的物体
    private Transform special_Trans;

    void Awake()
    {
        _instance = this;
    }

    void Enable()
    {

    }

    void Start()
    {
        this.enabled = false;
    }

    // 初始化编辑层的数据
    void OnDisable()
    {
        isMouseDown = false;
        lastMousePosition = Vector3.zero;
        if (special_Trans != null)
        {
            Vector3 temp = special_Trans.localPosition;
            special_Trans.localPosition = new Vector3(0, temp.y);
        }
    }

    public void SetSpecialTrans(Transform trans)
    {
        this.special_Trans = trans;
        if (trans != null)
        {
            GameObject dir_line = special_Trans.GetComponent<Transform>("line").gameObject;
            dir_line.SetActive(true);
        }
    }


    // 释放特殊物体
    public void DropSpecObj()
    {
        //special_Trans.gameObject.AddComponent<Rigidbody2D>();
        GameObject dir_line = special_Trans.GetComponent<Transform>("line").gameObject;
        dir_line.SetActive(false);
        special_Trans.gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }
        if (isMouseDown && special_Trans != null)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                tempVector3 = new Vector3(special_Trans.position.x + offset.x, special_Trans.position.y);
                special_Trans.position = tempVector3;
                checkPosition();
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    // 限制拖拽边界
    private void checkPosition()
    {
        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;
        if (x < -limit_width)
        {
            x = -limit_width;
        }
        if (x > limit_width)
        {
            x = limit_width;
        }
        if (y < -limit_height)
        {
            y = -limit_height;
        }
        if (y > limit_height)
        {
            y = limit_height;
        }
        transform.position = new Vector3(x, y, 0);
    }
    /// <summary>
    /// 球体碰撞到旋涡后的逻辑处理
    /// </summary>
    /// <param name="trans">球体</param>
    /// <param name="inVector3">in旋涡位置</param>
    /// <param name="outVector3">out旋涡位置</param>
    /// <param name="time">动画时间</param>
    public void OnCollisionToDelivery(Transform trans,float time)
    {
        // 球体进入旋涡逻辑1
        Rigidbody2D r2d = trans.GetComponent<Rigidbody2D>();
        Vector2 speed = r2d.velocity;
        Debug.Log("speed - >" + speed);
        trans.GetComponent<CircleCollider2D>().enabled = false;
        r2d.simulated = false;
        trans.DOMove(DeliveryInVec2, time).SetAutoKill(true);
        Tweener t = trans.DOScale(0.01f, time).SetDelay(0.5f).SetAutoKill(true);
        t.OnComplete(delegate
        {
            // 球体离开旋涡逻辑2            
            trans.position = DeliveryOutVec2;
            trans.DOMoveX(DeliveryOutVec2.x +1, time).SetAutoKill(true);
            Tweener t1 = trans.DOScale(1.0f, time).SetDelay(0.5f).SetAutoKill(true);
            t1.OnComplete(delegate
            {
                trans.GetComponent<CircleCollider2D>().enabled = true;                
                r2d.simulated = true;
                Vector2 temp = new Vector2(DeliveryOut.Instance.ForceX, DeliveryOut.Instance.ForceY);
                r2d.AddForce(temp);
                r2d.velocity = 0.0001f * Vector2.one;
            });
        });
       

    }
}

