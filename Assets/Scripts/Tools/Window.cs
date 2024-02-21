using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Window : MonoBehaviour
{

    private Tweener scale_forward;
    private Tweener scale_backward;
    public float scale_time;

    public GameObject close;
    public Ease EaseForward = Ease.OutBounce ;
    public Ease EaseBackward = Ease.OutBack;

    public Action OnHideComplete = delegate {};
    public Action OnShowComplete = delegate {};

    void Awake()
    {
        if (scale_time == 0)
        {
            scale_time = 0.7f;
        }
    }


    void Start()
    {
        transform.localScale = Vector3.zero;

        scale_forward = transform.DOScale(1.0f, scale_time).SetAutoKill(false).SetEase(EaseForward).Pause();
        scale_backward = transform.DOScale(0f, scale_time).SetAutoKill(false).SetEase(EaseBackward).Pause();

        if(close !=null) EventListener.Get(close).SetEventListener(E_TouchType.OnClick, OnCloseClick,null);
    }

    private void OnCloseClick(GameObject target, object eventData, object[] _params)
    {
        Hide();
    }

    public void Show(Action OnAction = null)
    {
        scale_forward.Restart();
        scale_forward.OnComplete(() =>
        {
            if (OnAction == null)
            {
                OnShowComplete();
                //Debug.Log("无参数的Show");
            }
            else
            {
                OnAction();
                //Debug.Log("有参数的show");
            }
        });
    }

    public void Hide(Action OnAction = null)
    {
        transform.localScale = Vector3.one;
        scale_backward.Restart();
        scale_backward.OnComplete(delegate {

            if (OnAction == null)
            {
                OnHideComplete();    
                //Debug.Log("无参数的hide");
            }
            else
            {
                OnAction();
                //Debug.Log("有参数的hide");
            }
        });
    }
}
