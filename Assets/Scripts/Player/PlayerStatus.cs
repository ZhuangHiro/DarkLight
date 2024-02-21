using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroType
{
    Swordman,
    Magician
}
public class PlayerStatus : MonoBehaviour {

    public HeroType heroType;//角色类型

    public int Level = 1;//等级
    public int Hp = 100;//血量
    public int Mp = 100;//魔法值
    public int Coin = 200;//金钱数量

    public int attack = 20;//攻击力
    public int attack_plus = 0;//添加的攻击力点数
    public int def = 20;//防御力
    public int def_plus = 0;//添加的防御力点数
    public int speed = 20;//速度
    public int speed_plus = 0;//添加的速度点数
    public int point_remain = 0;//剩余的点数

    public void GetCoint(int count)
    {
        Coin += count;
    }
    public bool GetPoint(int point=1)
    {
        if (point_remain >= point)
        {
            point_remain -= point;
            return true;
        }
        return false;
    }
}
