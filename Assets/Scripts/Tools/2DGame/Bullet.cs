using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{

    public int attack_value = 5;
    private float Speed = 5.0f;
    private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.right * Speed;
    }


    void Start()
    {

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Destroy(gameObject);
        }, 5.0f));
    }


    void Update()
    {
    }

   
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player") return;

        // 处理碰到怪物与碰到Boss，销毁子弹。
        if (coll.gameObject.tag == "Boss" || coll.gameObject.tag == "Enemy")
        {
            if (gameObject.tag != "SkillBullet")
            {
                Destroy(gameObject);
            }
        }
        // 如果不是技能子弹，碰撞到怪物的时候，销毁子弹
        if (gameObject.tag != "SkillBullet" && coll.gameObject.tag =="Enemy")
        {
            Destroy(gameObject);
        }
    }
}
