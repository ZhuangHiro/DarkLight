using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassUI : MonoBehaviour
{
    public int count = 0;
    void Start()
    {
        if (count == 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
