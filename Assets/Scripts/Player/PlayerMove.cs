using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    Moving,
    Idle
    }

public class PlayerMove : MonoBehaviour {
    public float speed = 1;
    public PlayerState state = PlayerState.Idle;
    public bool isMoving = false;
    private CharacterController controller;
    private PlayerDir dir;

	// Use this for initialization
	void Start () {
        controller = transform.GetComponent<CharacterController>();
        dir = transform.GetComponent<PlayerDir>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(dir.targetPosition, transform.position);//两个位置的距离
        if (distance > 0.1)
        {
            controller.SimpleMove(transform.forward * speed);
            state = PlayerState.Moving;
            isMoving = true;
        }
        else
        {
            state = PlayerState.Idle;
            isMoving = false;
        }
	}
}
