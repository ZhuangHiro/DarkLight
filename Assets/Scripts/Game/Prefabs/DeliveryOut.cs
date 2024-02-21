using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DeliveryOut : MonoBehaviour
{
    private static DeliveryOut _instance = null;

    public static DeliveryOut Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("DeliveryOut Instance is null ");
            }

            return _instance;
        }
    }
    // 传送门出口的受力
    public float ForceX;
    public float ForceY;

    private bool isOnGround = false;

    void Awake()
    {
        _instance = this;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == StringUtils.Ground)
        {
            isOnGround = true;
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Vector2 delivery_pos = transform.position;
            MoveController.Instance.DeliveryOutVec2 = delivery_pos;
        }
    }

    //public void OutDeliveryOut(Transform trans)
    //{
    //    if(!isOnGround) return;

    //    Vector3 disVector3 = new Vector3(transform.position.x, transform.position.y);
    //    trans.position = disVector3;
    //    trans.DOMoveX(disVector3.y + 50, 1.0f).SetAutoKill(true);
    //    Tweener t = trans.DOScale(1.0f, 1.0f).SetDelay(0.5f).SetAutoKill(true);
    //    t.OnComplete(delegate
    //    {
    //        trans.GetComponent<CircleCollider2D>().enabled = true;
    //        Rigidbody2D r2d =trans.GetComponent<Rigidbody2D>();
    //        r2d.simulated = true;
    //        //Vector2 temp = new Vector2(ForceX, ForceY);
    //        //r2d.AddForce(temp);
    //        //r2d.velocity = 0.0001f * Vector2.one;
    //    });
    //}

}
