using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Transform player;
    private Vector3 offsetPosition;//偏移
    public bool isRotating = false;
    public float distance = 0;
    public float scrollSpeed = 10;
    public float rotateSpeed = 1;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = offsetPosition + player.position;
        RotateView();
        ScrollView();
	}

    //处理视野的拉近与拉远效果
    void ScrollView()
    {
        //print(Input.GetAxis("Mouse ScrollWheel"));
        distance = offsetPosition.magnitude;//偏移的向量长度
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 10);//钳制
        offsetPosition = offsetPosition.normalized * distance;//normalized表示归一化，即向量方向不变，长度变为一
    }

    //处理视野的左右滑动
    void RotateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            Vector3 ariginalPosition = transform.position;
            Quaternion ariginalRotation = transform.rotation;

            transform.RotateAround(player.position, Vector3.up, rotateSpeed * Input.GetAxis("Mouse X"));
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));
            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)
            {
                transform.position = ariginalPosition;
                transform.rotation = ariginalRotation;
            }
        }
        offsetPosition = transform.position - player.position;
    }
}
