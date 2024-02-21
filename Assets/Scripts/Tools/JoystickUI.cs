using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 摇杆组成，背景 + 摇杆，该脚本挂载到背景上。
/// </summary>
public class JoystickUI : MonoBehaviour
{
    private static JoystickUI _instance = null;

    public static JoystickUI Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("JoystickUI instance is null...");
            }
            return _instance;
        }
    }
    private ScrollCircle scrollCircle;

    void Awake()
    {
        _instance = this;
        scrollCircle = transform.GetComponent<ScrollCircle>("ScrollCircle");
    }
    /// <summary>
    /// 获取knob的偏移单位向量
    /// </summary>
    /// <returns></returns>
    public Vector2 getKnobVector()
    {
        //Debug.Log("Vector:" + scrollCircle.ForceVector);
        return scrollCircle.ForceVector;
    }

    /// <summary>
    /// 2D精灵获取旋转角度，例如贪吃蛇蛇头。
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public Vector3 GetRotation(Vector3 temp)
    {
        float angle;
        Vector3 v = Vector3.zero;
        //angle = (180 * Mathf.Acos(temp.x / Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y)) / Mathf.PI);
        angle = (180 * Mathf.Acos(temp.x / Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y)) / Mathf.PI);
        // 1、4象限
        if (Mathf.Acos(temp.x / Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y)) != 0)
        {
            if (angle > 0 && angle <= 90)
            {
                if (temp.y > 0)
                    v = new Vector3(0, 0, angle + 90f);
                else
                    v = new Vector3(0, 0, -angle + 90f);
            }
            // 2、3象限，蓝色为重复
            else if (angle > 90 && angle <= 180f)
            {
                if (temp.y > 0)
                    v = new Vector3(0, 0, angle + 90f);
                else
                    v = new Vector3(0, 0, -angle + 90f);
            }
        }

        if (v == Vector3.zero)
            return Vector3.zero;
        else
            return v;
    }
}