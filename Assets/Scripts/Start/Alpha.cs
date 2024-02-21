using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {
        this.GetComponent<Image>().DOFade(0, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
