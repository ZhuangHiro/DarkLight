using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTools : MonoBehaviour
{

    private static ColorTools instance = null;

    private ColorTools()
    {
    }
    public static ColorTools GetInstance()
    {
        if (instance == null)
        {
            instance = new ColorTools();
        }
        return instance;
    }
    

    public Color GetColor(float r, float g, float b, float a)
    {
        Color color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        return color;
    }

}
