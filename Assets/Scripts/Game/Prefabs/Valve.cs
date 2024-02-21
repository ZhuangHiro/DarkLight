using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    private Transform up_trans;
    private Transform down_trans;
    // 指定该开关对应需要移动的砖块
    public AthleticBrick athleticBrick;
    void Awake()
    {
        up_trans = transform.GetComponent<Transform>("Up");
        down_trans = transform.GetComponent<Transform>("Down");
        up_trans.gameObject.SetActive(true);
        down_trans.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != StringUtils.Ground)
        {
            up_trans.gameObject.SetActive(false);
            down_trans.gameObject.SetActive(true);
            athleticBrick.PlayForewardMove();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != StringUtils.Ground)
        {
            up_trans.gameObject.SetActive(true);
            down_trans.gameObject.SetActive(false);
            athleticBrick.PlayBackwardMove();
        }
    }
}
