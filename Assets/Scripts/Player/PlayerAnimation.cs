using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private PlayerMove move;
	// Use this for initialization
	void Start () {
        move = this.GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (move.state == PlayerState.Moving)
        {
            PlayAnim("Run");
        }else if (move.state == PlayerState.Idle)
        {
            PlayAnim("Idle");
        }
	}

    //设置动画淡入淡出的方法
    void PlayAnim(string animName)
    {
        this.GetComponent<Animation>().CrossFade(animName);
    }
}
