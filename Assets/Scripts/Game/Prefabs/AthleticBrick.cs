using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AthleticBrick : MonoBehaviour
{
    public Vector3 disPosition;
    private Vector3 startPosition;
    private float duraiton = 3.0f;
    private Tweener moveTweener;
    void Awake()
    {
        moveTweener = transform.DOMove(disPosition, duraiton).Pause().SetAutoKill(false);
        startPosition = transform.position;
    }

    
    void Update()
    {
        
    }

    public void PlayForewardMove()
    {
        moveTweener.Pause();
        moveTweener.Play();
    }
    public void PlayBackwardMove()
    {
        moveTweener.Pause();
        transform.DOMove(startPosition, duraiton);
    }

    //void OnCollisionEnter2D(Collider2D col)
    //{
    //    if (col.tag == StringUtils.Circle)
    //    {
            
    //    }
    //}    
}
