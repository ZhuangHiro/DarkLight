using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameController Instance is null...");
            }

            return _instance;
        }
    }

    // ActorsRoot
    public Transform actors_transform;

    // 起始点的挡板
    private Transform hinder;
    // 道具位置编辑面板
    private Transform editor_root;
    //移动控制器
    private MoveController moveController;
    // 虚线
    private Transform lines;
    
    //玻璃
    public GameObject glass_special_obj;
    //橡胶
    public GameObject rubber_special_obj;
    //木箱
    public GameObject wood_special_obj;
    //传送门入
    public GameObject deliveryIn_special_obj;
    //传送门出
    public GameObject deliveryOut_special_obj;


    void Awake()
    {
        _instance = this;

        // 初始化道具
        hinder = actors_transform.GetComponent<Transform>("start_point/platform/hinder");
        editor_root = actors_transform.GetComponent<Transform>("editor_root");
        lines = actors_transform.GetComponent<Transform>("line");

        moveController = transform.GetComponent<MoveController>();
    }
    void Start()
    {
        // 游戏状态切换为Playing 
        // GameStateManager.Instance.current_state = GameState.Playing;
        InitEditorModel();
    }



    // 隐藏开始漏斗状态
    public void HideHinder()
    {
        hinder.GetComponent<SpriteRenderer>().DOFade(0, 0.5f).OnComplete(delegate
        {
            hinder.gameObject.SetActive(false);
        });
    }

    private void InitEditorModel()
    {
        lines.gameObject.SetActive(false);

    }

    // 下落编辑面板的显示隐藏
    public void EnableEditorModel(int id = 0)
    {
        if(lines.gameObject.activeInHierarchy) return;
        moveController.enabled = true;
        GameObject specObj = null;

        switch (id)
        {
            case 0:
                specObj = Instantiate(wood_special_obj);
                specObj.transform.position = new Vector3(0, 9, 0);
                break;
            case 1:                
                specObj = Instantiate(glass_special_obj);
                specObj.transform.position = new Vector3(0,9,0);
                break;
            case 2:                
                specObj = Instantiate(rubber_special_obj);
                specObj.transform.position = new Vector3(0, 9, 0);
                break;
            case 3:
                specObj = Instantiate(deliveryIn_special_obj);
                specObj.transform.position = new Vector3(0, 9, 0);
                break;
            case 4:
                specObj = Instantiate(deliveryOut_special_obj);
                specObj.transform.position = new Vector3(0, 9, 0);
                break;
            default:
                Debug.Log("无匹配的特殊物体");
                break;
        }
        lines.gameObject.SetActive(true);
        if (specObj != null)
        {
            moveController.SetSpecialTrans(specObj.transform);
        }
    }
    // 特殊物体掉落
    public void DisableEditorModel()
    {
        lines.gameObject.SetActive(false);
        moveController.DropSpecObj();
        moveController.SetSpecialTrans(null);
        moveController.enabled = false;
    }

    void Update()
    {

    }




    //方法，胜利的判断
    private bool JudgeGameWin()
    {
        return true;
    }
}
