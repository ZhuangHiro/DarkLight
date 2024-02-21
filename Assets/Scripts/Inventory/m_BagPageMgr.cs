using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class m_BagPageMgr : MonoBehaviour

{

    Transform _Panle;//保存Panle的Transform 
    Transform BackGound;//保存BackGround的Transform

    void Awake()

    {
        _Panle = transform.parent.GetComponent<Transform>();//获取到Transform组件
        BackGound = GetComponent<Transform>();//获取到Transform组件
        Inst = this;//初始化实例
    }

    private m_BagPageMgr()//私有化构造方法,使外部不能随意实例化该类
    {

    }

    static m_BagPageMgr Inst;//定义一个静态的私有的实例

    public static m_BagPageMgr Instance//使用属性获取上面的实例

    {
        get
        {
            return Inst;
        }

    }

    public Transform getPanle//使用属性获取Panle的Transform

    {
        get
        {
            return _Panle;
        }
    }

    public Transform getBG//使用属性获取BackGround的Transform

    {
        get
        {
            return BackGound;
        }
    }
}
