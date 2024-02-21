
using System;
using System.Collections.Generic;



/// <summary>
/// 事件分发函数。
/// 提供事件注册， 反注册， 事件触发
/// 采用 delegate, dictionary 实现
/// 支持自定义事件。 事件采用字符串方式标识
/// 支持 0，1，2，3 等4种不同参数个数的回调函数
/// </summary>
public class EventDispatcher
{
    private static EventController _eventController = new EventController();

    public static Dictionary<E_eventType, Delegate> TheRouter
    {
        get { return _eventController.TheRouter; }
    }

    /// <summary>
    /// 标记为永久注册事件
    /// </summary>
    /// <param name="eventType"></param>
    static public void MarkAsPermanent(E_eventType eventType)
    {
        _eventController.MarkAsPermanent(eventType);
    }

    /// <summary>
    /// 清除非永久性注册的事件
    /// </summary>
    static public void Cleanup()
    {
        _eventController.Cleanup();
    }

    #region 增加监听器
    /// <summary>
    ///  增加监听器， 不带参数
    /// </summary>
    static public void AddListener(E_eventType eventType, Action handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 1个参数
    /// </summary>
    static public void AddListener<T>(E_eventType eventType, Action<T> handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 2个参数
    /// </summary>
    static public void AddListener<T, U>(E_eventType eventType, Action<T, U> handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 3个参数
    /// </summary>
    static public void AddListener<T, U, V>(E_eventType eventType, Action<T, U, V> handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 4个参数
    /// </summary>
    static public void AddListener<T, U, V, W>(E_eventType eventType, Action<T, U, V, W> handler)
    {
        _eventController.AddListener(eventType, handler);
    }
    #endregion

    #region 移除监听器
    /// <summary>
    ///  移除监听器， 不带参数
    /// </summary>
    static public void RemoveListener(E_eventType eventType, Action handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 1个参数
    /// </summary>
    static public void RemoveListener<T>(E_eventType eventType, Action<T> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 2个参数
    /// </summary>
    static public void RemoveListener<T, U>(E_eventType eventType, Action<T, U> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 3个参数
    /// </summary>
    static public void RemoveListener<T, U, V>(E_eventType eventType, Action<T, U, V> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 4个参数
    /// </summary>
    static public void RemoveListener<T, U, V, W>(E_eventType eventType, Action<T, U, V, W> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }
    #endregion

    #region 触发事件
    /// <summary>
    ///  触发事件， 不带参数触发
    /// </summary>
    static public void TriggerEvent(E_eventType eventType)
    {
        _eventController.TriggerEvent(eventType);
    }

    /// <summary>
    ///  触发事件， 带1个参数触发
    /// </summary>
    static public void TriggerEvent<T>(E_eventType eventType, T arg1)
    {
        _eventController.TriggerEvent(eventType, arg1);
    }

    /// <summary>
    ///  触发事件， 带2个参数触发
    /// </summary>
    static public void TriggerEvent<T, U>(E_eventType eventType, T arg1, U arg2)
    {
        _eventController.TriggerEvent(eventType, arg1, arg2);
    }

    /// <summary>
    ///  触发事件， 带3个参数触发
    /// </summary>
    static public void TriggerEvent<T, U, V>(E_eventType eventType, T arg1, U arg2, V arg3)
    {
        _eventController.TriggerEvent(eventType, arg1, arg2, arg3);
    }

    /// <summary>
    ///  触发事件， 带4个参数触发
    /// </summary>
    static public void TriggerEvent<T, U, V, W>(E_eventType eventType, T arg1, U arg2, V arg3, W arg4)
    {
        _eventController.TriggerEvent(eventType, arg1, arg2, arg3, arg4);
    }

    #endregion
}
