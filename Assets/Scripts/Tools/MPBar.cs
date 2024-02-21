using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 当前物体挂载在进度条上，其必须含有子物体名称为fill，否则无法使用。
/// 仅适用于伸缩形进度条。
/// </summary>
public class MPBar : MonoBehaviour
{
    private static MPBar _instance = null;
    public static MPBar Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MPBar is null...");
            }

            return _instance;
        }
    }
    // 默认调整好的进度条100%的宽度
    private float fill_whole_width;
    //默认调整好的进度条100%时候的X轴位置。
    private float fill_local_pos_x;
    // 填充进度条的填充块儿。
    private Transform fill;

    void Awake()
    {
        _instance = this;

        InitUI();
    }

    private void InitUI()
    {
        fill = transform.Find("fill");
        fill_whole_width = fill.GetComponent<RectTransform>().rect.width;
        fill_local_pos_x = fill.localPosition.x;
    }
    /// <summary>
    /// 更新当前游戏中主角的魔法值进度条
    /// </summary>
    /// <param name="MP">主角当前MP值</param>
    /// <param name="MP_MAX">主角MP最大值</param>
    public void UpdateHPBar(float MP = 0, float MP_MAX = 100)
    {
        float temp = 0;
        if (MP <= 0.001f)
        {
            temp = 0;
        }
        else
        {
            temp = MP / MP_MAX;
        }

        transform.DOScaleX(temp, 0.5f);
        // 位移，因为锚点为中心点，所以宽度要除以2.
        float temp_x = (1 - temp) * fill_whole_width / 2;
        float target_posx = fill_local_pos_x - temp_x;
        transform.DOLocalMoveX(target_posx, 0.5f);
    }
}
