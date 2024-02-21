using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 当前物体挂载在进度条上，其必须含有子物体名称为fill，否则无法使用。
/// 进度条文本展示，在其子物体创建1个名字为“progress_text”控件，即可显示进度百分比，是否展示通过isShowText布尔来控制
/// 仅适用于伸缩形进度条，MP的进度条赋值一份即可。
/// </summary>
public class ProgressBar : MonoBehaviour
{
    private static ProgressBar _instance = null;
    public static ProgressBar Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("ProgressBar is null...");
            }

            return _instance;
        }
    }

    private float fill_whole_width;
    private float fill_local_pos_x;
    // 填充进度条的填充块儿。
    private Transform fill;
    // 向左缩进，还是向右缩进。
    public bool isLeft = true;

    // 显示加载进度的文本
    private Text progress_text;
    // 是否显示进度条文本
    public bool isShowText;


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

        //初始化填充区域起始点位置
        //血条想左缩进。
        if (isLeft)
        {
            // 位移，因为锚点为中心点，所以宽度要除以2.
            float temp_x = fill_whole_width / 2;
            float target_posx = fill_local_pos_x - temp_x;
            fill.DOLocalMoveX(target_posx, 0.001f);
            
        }
        else
        {
            float temp_x = fill_whole_width / 2;
            float target_posx = fill_local_pos_x + temp_x;
            fill.DOLocalMoveX(target_posx, 0.001f);
        }

        if (isShowText)
        {
            progress_text = transform.GetComponent<Text>("progress_text");
        }
        else
        {
            progress_text = transform.GetComponent<Text>("progress_text");
            progress_text.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// 更新当前游戏中主角的生命值进度条
    /// </summary>
    /// <param name="HP">主角当前HP值</param>
    /// <param name="HP_MAX">主角HP最大值</param>
    public void UpdateHPBar(float HP = 0, float HP_MAX = 100)
    {
        if (HP > HP_MAX) return;
        float temp = 0;
        if (HP <= 0.001f)
        {
            temp = 0;
        }
        else
        {
            temp = HP / HP_MAX;
        }

        fill.DOScaleX(temp, 0.5f);

        //血条想左缩进。
        if (isLeft)
        {
            // 位移，因为锚点为中心点，所以宽度要除以2.
            float temp_x = (1 - temp) * fill_whole_width / 2;
            float target_posx = fill_local_pos_x - temp_x;
            fill.DOLocalMoveX(target_posx, 0.5f);
        }
        else
        {
            float temp_x = (1 - temp) * fill_whole_width / 2;
            float target_posx = fill_local_pos_x + temp_x;
            fill.DOLocalMoveX(target_posx, 0.5f);
        }

        if (isShowText) this.setText(HP);
    }
    /// <summary>
    /// 设置进度
    /// </summary>
    /// <param name="value"></param>
    public void setText(float value)
    {
        progress_text.text = "(" + value + ")";
    }


}
