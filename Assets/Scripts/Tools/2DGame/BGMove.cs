using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BGMove : MonoBehaviour
{
    public float Speed = 2.0f;
    void Awake()
    {
        
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 角色死亡，背景不移动
        // if (Player.Instance.IsDead()) return;

        // 暂停状态，背景不移动。
        //if (Player.Instance.IsPause) return;

        // Boss状态，背景不移动。
        //if (Player.Instance.isBossState) return;

        transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if (transform.position.x <= -12.81f)
        {
            Vector3 temp = new Vector3(transform.position.x +12.81f * 2, transform.localPosition.y, 0);
            transform.position = temp;
        }
    }
}

