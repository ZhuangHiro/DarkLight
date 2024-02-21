using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircle : MonoBehaviour
{

    private static PlayerCircle _instance = null;

    public static PlayerCircle Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("PlayerCircle instance is null....");
            }

            return _instance;
        }
    }
    // 下落标签
    private bool isFall;
    //刚体
    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        _instance = this;

        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        rigidbody2D.simulated = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("小球速度：" + rigidbody2D.velocity);
    }

    void FixedUpdate()
    {
        if (isStatic() && isFall)
        {
            isFall = false;
            // MainUI.Instance.ShowFailUI();
        }
    }
 
    /// <summary>
    /// 释放球圈下落方法
    /// </summary>
    /// <param name="isTrue">是否下落方法</param>
    public void DropBall(bool isTrue = true)
    {
        rigidbody2D.simulated = isTrue;
        // 下落工程给1起始速度
        rigidbody2D.velocity = Vector2.one * 0.001f;
        isFall = true;
        transform.SetParent(null);
    }

    public bool isStatic()
    {
        bool isTrue = (rigidbody2D.velocity == Vector2.zero);
        return isTrue;
    }

}
