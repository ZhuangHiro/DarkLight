using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{

    private static DestinationPoint _instance = null;

    public static DestinationPoint Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("DestinationPoint instance is null....");
            }

            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.tag == StringUtils.Circle)
        {
            other.GetComponent<Rigidbody2D>().simulated = false;
            other.gameObject.SetActive(false);

            StartCoroutine(DelayToInvoke.DelayToInvokeDo(delegate
            {
                MainUI.Instance.ShowVectoryUI();
            }, 1.0f));

            // Debug.Log("小球进洞，游戏结束.....");
        }
    }
}
