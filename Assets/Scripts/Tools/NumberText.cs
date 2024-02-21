using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 自定义图片的数字，用于显示数字。
/// </summary>
[RequireComponent(typeof(Image))]
public class NumberText : MonoBehaviour
{
    // 0 - 9 的图片数字，需要手动拖进去。
    public Sprite[] numbers;

    private Image text;

	void Awake ()
	{
	    text = transform.GetComponent<Image>();
	}
	/// <summary>
    /// 
    /// </summary>
    /// <param name="index">要显示的数字</param>
 	public void UpdateText (int index) {
 	    switch (index)
 	    {
            case 0:
 	            text.overrideSprite = numbers[0];
                break;
            case 1:
                text.overrideSprite = numbers[1];
                break;
            case 2:
                text.overrideSprite = numbers[2];
                break;
        }
	}
}
