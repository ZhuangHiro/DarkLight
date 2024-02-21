using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using MadLevelManager;
using System;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    private static MainUI _instance;

    public static MainUI Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MainUI Instance is null...");
            }

            return _instance;
        }
    }
    
    // 重置场景UI
    private Transform reset_scene_button;
    // 星星标签
    // private Transform star_label;
    // 提示按钮
    private Transform tips_button;
    // 返回按钮
    private Transform back_button;
    // 下落按钮
    private Transform fall_button;
    // 开始页面黑色遮罩
    private Image black_mask;

    private Tweener black_mask_tweener;
    // 胜利面板
    private Transform vectory_panel;
    // 失败面板
    private Transform lose_panel;

    // 测试的特殊道具
    private Transform wood_tool_button;
    private Transform glass_tool_button;
    private Transform rubber_tool_button;    
    private Transform deliveryIn_tool_button;
    private Transform deliveryOut_tool_button;

    public int WOOD_COUNT = 0;
    public int GLASS_COUNT = 0;
    public int RUBBER_COUNT = 0;
    public int DELIVERY_IN_COUNT = 0;
    public int DELIVERY_OUT_COUNT = 0;

    //下落按钮锁
    private bool FallLock;


    void Awake()
    {
        _instance = this;
        Debug.Log("启动游戏......");
        this.FallLock = false;

        // star_label = transform.GetComponent<Transform>("stars_label");
        reset_scene_button = transform.GetComponent<Transform>("reset_scene_button");
        tips_button = transform.GetComponent<Transform>("tips_button");
        back_button = transform.GetComponent<Transform>("back_button");
        fall_button = transform.GetComponent<Transform>("dorp_button");

        black_mask = transform.GetComponent<Image>("black_mask");
        black_mask_tweener = black_mask.DOFade(0, 1.0f).SetAutoKill(true).Pause();

        vectory_panel = transform.GetComponent<Transform>("Popup/VectoryUI");
        lose_panel = transform.GetComponent<Transform>("Popup/LoseUI");

        rubber_tool_button = transform.GetComponent<Transform>("Tools/rubber_tool");
        glass_tool_button = transform.GetComponent<Transform>("Tools/glass_tool");
        wood_tool_button = transform.GetComponent<Transform>("Tools/wooden_tool");
        deliveryIn_tool_button = transform.GetComponent<Transform>("Tools/deliveryIn_tool");
        deliveryOut_tool_button = transform.GetComponent<Transform>("Tools/deliveryOut_tool");
    }


    void Start()
    {

        //this.ShowVectoryUI();

        //this.ShowFailUI();

        // 启动黑屏
        ShowBlackMask();

        // EventListener.Get(star_label).SetEventListener(E_TouchType.OnClick, OnStarLabelClick, null);
        EventListener.Get(reset_scene_button).SetEventListener(E_TouchType.OnClick, OnResetSceneClick, null);
        EventListener.Get(tips_button).SetEventListener(E_TouchType.OnClick, OnTipsClick, null);
        EventListener.Get(back_button).SetEventListener(E_TouchType.OnClick, OnBackClick, null);
        EventListener.Get(fall_button).SetEventListener(E_TouchType.OnClick, OnDropClick, null);

        EventListener.Get(rubber_tool_button).SetEventListener(E_TouchType.OnClick, OnRubberClick, null);
        EventListener.Get(glass_tool_button).SetEventListener(E_TouchType.OnClick, OnGlassClick, null);
        EventListener.Get(wood_tool_button).SetEventListener(E_TouchType.OnClick, OnWoodClick, null);
        EventListener.Get(deliveryIn_tool_button).SetEventListener(E_TouchType.OnClick, OnDeliveryInClick, null);
        EventListener.Get(deliveryOut_tool_button).SetEventListener(E_TouchType.OnClick, OnDeliveryOutClick, null);

    }
    private void OnWoodClick(GameObject target, object eventData, object[] _params)
    {
        GameController.Instance.EnableEditorModel(0);
    }
    private void OnGlassClick(GameObject target, object eventData, object[] _params)
    {
        GameController.Instance.EnableEditorModel(1);
    }
    private void OnRubberClick(GameObject target, object eventData, object[] _params)
    {
        GameController.Instance.EnableEditorModel(2);
    }
    private void OnDeliveryInClick(GameObject target, object eventData, object[] _params)
    {
        GameController.Instance.EnableEditorModel(3);
    }
    private void OnDeliveryOutClick(GameObject target, object eventData, object[] _params)
    {
        GameController.Instance.EnableEditorModel(4);
    }

    private void ShowBlackMask()
    {
        black_mask.transform.localScale = Vector3.one;
        black_mask_tweener.Restart();
        black_mask_tweener.OnComplete(delegate
        {
            black_mask.gameObject.SetActive(false);
        });
    }

    private void OnDropClick(GameObject target, object eventdata, object[] _params)
    {

        if (MoveController.Instance.enabled)
        {
            GameController.Instance.DisableEditorModel();
        }
        else
        {
            if(FallLock) return;
            this.FallLock = true;
            // 下落代码
            GameController.Instance.HideHinder();
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(delegate
            {
                PlayerCircle.Instance.DropBall();
            }, 0.5f));
        }
    }

    private void OnBackClick(GameObject target, object eventdata, object[] _params)
    {
        Debug.Log("OnBackClick......");
    }

    private void OnTipsClick(GameObject target, object eventdata, object[] _params)
    {
        Debug.Log("OnTipsClick........");
    }

    private void OnResetCircleClick(GameObject target, object eventdata, object[] _params)
    {
        Debug.Log("OnResetCircleClick........");
    }

    private void OnResetSceneClick(GameObject target, object eventdata, object[] _params)
    {
        MadLevel.ReloadCurrent();        
        Debug.Log("OnResetSceneClick......");
    }

    private void OnStarLabelClick(GameObject target, object eventdata, object[] _params)
    {
        Debug.Log("OnStarLabelClick......");
    }

    // 展示胜利面板
    public void ShowVectoryUI()
    {
        vectory_panel.gameObject.SetActive(true);
        Debug.Log("游戏【胜利】面板...展示...");
    }
    // 展示失败面板
    public void ShowFailUI()
    {
        lose_panel.gameObject.SetActive(true);
        Debug.Log("游戏【失败】面板...展示...");
    }
}