using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFitIPad : MonoBehaviour
{
    public float x,y;
    public float fit_scale = 1;

    private int screen_width;
    private int screen_height;

    // Use this for initialization

    private void Awake()
    {
        screen_width = Screen.width;
        screen_height = Screen.height;
        //Debug.Log("屏幕宽度：" + screen_width + " | " + "屏幕高度：" + screen_height);
    }

    void Start()
    {

        if (screen_width >= StringUtils.IPAD_PRO_SCREEN_WIDITH && screen_height >= StringUtils.IPAD_PRO_SCREEN_HEIGHT)
        {
            Vector3 temp = transform.localPosition;
        
            Vector3 target = new Vector3(temp.x - x,temp.y - y,0);

            transform.localPosition = target;
        }
        
        if (screen_width >= StringUtils.IPAD_PRO_SCREEN_WIDITH && screen_height >= StringUtils.IPAD_PRO_SCREEN_HEIGHT)
        {
            
            if(fit_scale == 0) return;
            
            Vector3 temp = transform.localScale;
        
            Vector3 target = new Vector3(temp.x * fit_scale,temp.y * fit_scale,0);

            transform.localScale = target;
        }
    }

}