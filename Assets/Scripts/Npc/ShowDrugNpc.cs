using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDrugNpc : MonoBehaviour {

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShopDrug._instance.TransformState();
        }
    }
}
