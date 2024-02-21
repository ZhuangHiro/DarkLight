using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwan : MonoBehaviour
{
    private static BulletSpwan _instance = null;
    public static BulletSpwan Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("BulletSpwan is null...");
            }

            return _instance;
        }
    }

    private GameObject bullet;

    void Awake()
    {
        _instance = this;
    }


    public void CreateBullet()
    {
        GameObject go = Resources.Load<GameObject>("Prefabs/Bullet/bullet");
        GameObject bullet = Instantiate(go) as GameObject;
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = Vector3.zero;
        bullet.transform.localScale = new Vector3(0.32f, 0.65f, 0);
    }

    public void CreateSkillBullet()
    {
        GameObject go = Resources.Load<GameObject>("Prefabs/Bullet/skill_bullet");
        GameObject bullet = Instantiate(go) as GameObject;
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = new Vector3(0.73f,0.22f,0);
        bullet.transform.localScale = new Vector3(0.78f, 0.78f, 0);
    }

}
