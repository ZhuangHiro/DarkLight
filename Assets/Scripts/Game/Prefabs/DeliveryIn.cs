using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DeliveryIn : MonoBehaviour
{
    private static DeliveryIn _instance = null;

    public static DeliveryIn Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("DeliveryIn Instance is null ");
            }

            return _instance;
        }
    }

    private Tweener rotateTweener;
    private Transform content;
    private Tweener rot_tweener;

    void Awake()
    {
        _instance = this;

        content = transform.GetComponent<Transform>("content");
        Debug.Log(content.name);
        rot_tweener = content.DOLocalRotate(new Vector3(0, 0, -360), 10);
        rot_tweener.SetLoops(-1, LoopType.Restart);
        rot_tweener.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == StringUtils.Ground)
        {
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Vector2 delivery_pos = transform.position;
            MoveController.Instance.DeliveryInVec2 = delivery_pos;
        }

        if (col.transform.tag == StringUtils.Circle)
        {
            MoveController.Instance.OnCollisionToDelivery(col.transform,1.0f);
        }
    }

    //public void OnCollisionToDeliveryIn(Transform trans,Vector3 disVector3)
    //{
    //    trans.GetComponent<CircleCollider2D>().enabled = false;
    //    trans.GetComponent<Rigidbody2D>().simulated = false;
    //    trans.DOMove(disVector3, 1.0f).SetAutoKill(true);
    //    Tweener t = trans.DOScale(0.01f, 1.0f).SetDelay(0.5f).SetAutoKill(true);
    //    t.OnComplete(delegate
    //    {
    //        DeliveryOut.Instance.OutDeliveryOut(trans);
    //    });
    //}

}
