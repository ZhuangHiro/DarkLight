//#define LOG_ALL_MESSAGES
//#define LOG_ADD_LISTENER
//#define LOG_BROADCAST_MESSAGE
using System;
using System.Collections.Generic;

public enum E_eventType
{

}


/// <summary>
/// 事件处理类。
/// </summary>
public class EventController
{
    private Dictionary<E_eventType, Delegate> m_theRouter = new Dictionary<E_eventType, Delegate>();

    public Dictionary<E_eventType, Delegate> TheRouter
    {
        get { return m_theRouter; }
    }

    /// <summary>
    /// 永久注册的事件列表
    /// </summary>
    private List<E_eventType> m_permanentEvents = new List<E_eventType>();

    /// <summary>
    /// 标记为永久注册事件
    /// </summary>
    /// <param name="eventType"></param>
    public void MarkAsPermanent(E_eventType eventType)
    {
#if LOG_ALL_MESSAGES
			DebugUtil.Info("Messenger MarkAsPermanent \t\"" + eventType + "\"");
#endif
        m_permanentEvents.Add(eventType);
    }

    /// <summary>
    /// 判断是否已经包含事件
    /// </summary>
    /// <param name="eventType"></param>
    /// <returns></returns>
    public bool ContainsEvent(E_eventType eventType)
    {
        return m_theRouter.ContainsKey(eventType);
    }

    /// <summary>
    /// 清除非永久性注册的事件
    /// </summary>
    public void Cleanup()
    {
#if LOG_ALL_MESSAGES
			DebugUtil.Info("MESSENGER Cleanup. Make sure that none of necessary listeners are removed.");
#endif
        List<E_eventType> eventToRemove = new List<E_eventType>();

        foreach (KeyValuePair<E_eventType, Delegate> pair in m_theRouter)
        {
            bool wasFound = false;
            foreach (E_eventType Event in m_permanentEvents)
            {
                if (pair.Key == Event)
                {
                    wasFound = true;
                    break;
                }
            }

            if (!wasFound)
                eventToRemove.Add(pair.Key);
        }

        foreach (E_eventType Event in eventToRemove)
        {
            m_theRouter.Remove(Event);
        }
    }

    /// <summary>
    /// 处理增加监听器前的事项， 检查 参数等
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="listenerBeingAdded"></param>
    private void OnListenerAdding(E_eventType eventType, Delegate listenerBeingAdded)
    {
#if LOG_ALL_MESSAGES || LOG_ADD_LISTENER
			DebugUtil.Info("MESSENGER OnListenerAdding \t\"" + eventType + "\"\t{" + listenerBeingAdded.Target + " -> " + listenerBeingAdded.Method + "}");
#endif

        if (!m_theRouter.ContainsKey(eventType))
        {
            m_theRouter.Add(eventType, null);
        }

        Delegate d = m_theRouter[eventType];
        if (d != null && d.GetType() != listenerBeingAdded.GetType())
        {
            throw new Exception(string.Format(
                "Try to add not correct event {0}. Current type is {1}, adding type is {2}.",
                eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
        }
    }

    /// <summary>
    /// 移除监听器之前的检查
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="listenerBeingRemoved"></param>
    private bool OnListenerRemoving(E_eventType eventType, Delegate listenerBeingRemoved)
    {
#if LOG_ALL_MESSAGES
			DebugUtil.Info("MESSENGER OnListenerRemoving \t\"" + eventType + "\"\t{" + listenerBeingRemoved.Target + " -> " + listenerBeingRemoved.Method + "}");
#endif

        if (!m_theRouter.ContainsKey(eventType))
        {
            return false;
        }

        Delegate d = m_theRouter[eventType];
        if ((d != null) && (d.GetType() != listenerBeingRemoved.GetType()))
        {
            throw new Exception(string.Format(
                "Remove listener {0}\" failed, Current type is {1}, adding type is {2}.",
                eventType, d.GetType(), listenerBeingRemoved.GetType()));
        }
        else
            return true;
    }

    /// <summary>
    /// 移除监听器之后的处理。删掉事件
    /// </summary>
    /// <param name="eventType"></param>
    private void OnListenerRemoved(E_eventType eventType)
    {
        if (m_theRouter.ContainsKey(eventType) && m_theRouter[eventType] == null)
        {
            m_theRouter.Remove(eventType);
        }
    }

    #region 增加监听器
    /// <summary>
    ///  增加监听器， 不带参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void AddListener(E_eventType eventType, Action handler)
    {
        OnListenerAdding(eventType, handler);
        m_theRouter[eventType] = (Action)m_theRouter[eventType] + handler;
    }

    /// <summary>
    ///  增加监听器， 1个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void AddListener<T>(E_eventType eventType, Action<T> handler)
    {
        OnListenerAdding(eventType, handler);
        m_theRouter[eventType] = (Action<T>)m_theRouter[eventType] + handler;
    }

    /// <summary>
    ///  增加监听器， 2个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void AddListener<T, U>(E_eventType eventType, Action<T, U> handler)
    {
        OnListenerAdding(eventType, handler);
        m_theRouter[eventType] = (Action<T, U>)m_theRouter[eventType] + handler;
    }

    /// <summary>
    ///  增加监听器， 3个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void AddListener<T, U, V>(E_eventType eventType, Action<T, U, V> handler)
    {
        OnListenerAdding(eventType, handler);
        m_theRouter[eventType] = (Action<T, U, V>)m_theRouter[eventType] + handler;
    }

    /// <summary>
    ///  增加监听器， 4个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void AddListener<T, U, V, W>(E_eventType eventType, Action<T, U, V, W> handler)
    {
        OnListenerAdding(eventType, handler);
        m_theRouter[eventType] = (Action<T, U, V, W>)m_theRouter[eventType] + handler;
    }
    #endregion

    #region 移除监听器

    /// <summary>
    ///  移除监听器， 不带参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener(E_eventType eventType, Action handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }

    /// <summary>
    ///  移除监听器， 1个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T>(E_eventType eventType, Action<T> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }

    /// <summary>
    ///  移除监听器， 2个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T, U>(E_eventType eventType, Action<T, U> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T, U>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }

    /// <summary>
    ///  移除监听器， 3个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T, U, V>(E_eventType eventType, Action<T, U, V> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T, U, V>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }

    /// <summary>
    ///  移除监听器， 4个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T, U, V, W>(E_eventType eventType, Action<T, U, V, W> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T, U, V, W>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }
    #endregion

    #region 触发事件
    /// <summary>
    ///  触发事件， 不带参数触发
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void TriggerEvent(E_eventType eventType)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
			DebugUtil.Info("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif

        Delegate d;
        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();
        for (int i = 0; i < callbacks.Length; i++)
        {
            Action callback = callbacks[i] as Action;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {

                callback();
            }
            catch (Exception ex)
            {
                //DebugUtil.Except(ex);
            }
        }
    }

    /// <summary>
    ///  触发事件， 带1个参数触发
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void TriggerEvent<T>(E_eventType eventType, T arg1)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
			DebugUtil.Info("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif

        Delegate d;
        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();
        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T> callback = callbacks[i] as Action<T>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback(arg1);
            }
            catch (Exception ex)
            {
                //DebugUtil.Except(ex);
            }
        }
    }

    /// <summary>
    ///  触发事件， 带2个参数触发
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void TriggerEvent<T, U>(E_eventType eventType, T arg1, U arg2)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
			DebugUtil.Info("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif

        Delegate d;
        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }
        var callbacks = d.GetInvocationList();
        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T, U> callback = callbacks[i] as Action<T, U>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback(arg1, arg2);
            }
            catch (Exception ex)
            {
                //DebugUtil.Except(ex);
            }
        }
    }

    /// <summary>
    ///  触发事件， 带3个参数触发
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void TriggerEvent<T, U, V>(E_eventType eventType, T arg1, U arg2, V arg3)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
			DebugUtil.Info("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif

        Delegate d;
        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }
        var callbacks = d.GetInvocationList();
        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T, U, V> callback = callbacks[i] as Action<T, U, V>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }
            try
            {
                callback(arg1, arg2, arg3);
            }
            catch (Exception ex)
            {
                //DebugUtil.Except(ex);
            }
        }
    }

    /// <summary>
    ///  触发事件， 带4个参数触发
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void TriggerEvent<T, U, V, W>(E_eventType eventType, T arg1, U arg2, V arg3, W arg4)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
			DebugUtil.Info("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif

        Delegate d;
        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }
        var callbacks = d.GetInvocationList();
        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T, U, V, W> callback = callbacks[i] as Action<T, U, V, W>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }
            try
            {
                callback(arg1, arg2, arg3, arg4);
            }
            catch (Exception ex)
            {
                //DebugUtil.Except(ex);
            }
        }
    }

    #endregion
}

