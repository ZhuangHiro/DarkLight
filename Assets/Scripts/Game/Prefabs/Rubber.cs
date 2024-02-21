using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float ForceX;
    public float ForceY;

    void Awake()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        transform.tag = StringUtils.Rubber;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.transform.tag == StringUtils.Ground)
        //{
        //    rigidbody2D.Sleep();
        //}


        if (col.transform.tag == StringUtils.Circle)
        {
            Rigidbody2D  otheRigidbody2D = col.transform.GetComponent<Rigidbody2D>();
            
            //Debug.Log("碰撞前：" + otheRigidbody2D.velocity);

            otheRigidbody2D.velocity = 0.0001f* Vector2.one;
            Vector2 temp = new Vector2(ForceX, ForceY);
            otheRigidbody2D.AddForce(temp);
            rigidbody2D.velocity = 0.0001f * Vector2.one;



            //Debug.Log("碰撞后：" + otheRigidbody2D.velocity);
        }
	}
}
