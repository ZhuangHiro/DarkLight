using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDir : MonoBehaviour {

    public GameObject effect_click_prefab;
    public Vector3 targetPosition = Vector3.zero;
    private bool isMoving = false;
    private PlayerMove playerMove;

    // Use this for initialization
    void Start() {
        targetPosition = transform.position;
        playerMove = this.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
          { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            bool isCollider = Physics.Raycast(ray, out hitinfo);
            if (isCollider && hitinfo.collider.tag == Tags.ground)
            {
                ShowClickEffect(hitinfo.point);
            }
            isMoving = true;
          }
        }
    
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false; 
        }

        //得到要移动的目标位置
        //让主角朝向目标位置
        if (isMoving)//鼠标抬起放开间
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            bool isCollider = Physics.Raycast(ray, out hitinfo);
            if (isCollider && hitinfo.collider.tag == Tags.ground)
            {
                LookAtTarget(hitinfo.point);
            }
        }
        else
        {
            if (playerMove.isMoving)//角色移动时
            {
                LookAtTarget(targetPosition);
            }
        }
    }
    //实例化点击效果的方法
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }

    //让主角朝向目标位置的方法
    void LookAtTarget(Vector3 hitPoint)
    {
        targetPosition = hitPoint;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        this.transform.LookAt(targetPosition);
    }
}

