using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SkillsInfo : MonoBehaviour {

    public TextAsset skillsInfoText;
    public static SkillsInfo _instance;

    private Dictionary<int, SkillInfo> skillInfoDict = new Dictionary<int, SkillInfo>();//建立字典
 
    void Awake()
    {
        _instance = this;
        InitSkillInfoDict();//初始化技能信息字典
    }

    public SkillInfo GetSkillinfoById(int id)
    {
        SkillInfo info = null;
        skillInfoDict.TryGetValue(id, out info);
        return info;
    }

    //初始化技能信息字典
    void InitSkillInfoDict()
    {
        string text = skillsInfoText.text;
        string[] skillinfoArray = text.Split('\n');
        foreach(string skillinfoStr in skillinfoArray)
        {
            string[] pa = skillinfoStr.Split(',');
            SkillInfo info = new SkillInfo();
            int id = int.Parse(pa[0]);
            info.name = pa[1];
            info.icon_name = pa[2];
            info.des = pa[3];
            string str_applytype = pa[4];
            switch (str_applytype)
            {
                case "Passive":
                    info.applyType = ApplyType.Passive;
                    break;
                case "Buff":
                    info.applyType = ApplyType.Buff;
                    break;
                case "SingleTarget":
                    info.applyType = ApplyType.SingleTarget;
                    break;
                case "MultiTarget":
                    info.applyType = ApplyType.MultiTarget;
                    break;
            }
            string str_applypro = pa[5];
            switch (str_applypro)
            {
                case "Attack":
                    info.applyProperty = ApplyProperty.Attack;
                    break;
                case "Def":
                    info.applyProperty = ApplyProperty.Def;
                    break;
                case "Speed":
                    info.applyProperty = ApplyProperty.Speed;
                    break;
                case "AttackSpeed":
                    info.applyProperty = ApplyProperty.AttackSpeed;
                    break;
                case "HP":
                    info.applyProperty = ApplyProperty.HP;
                    break;
                case "MP":
                    info.applyProperty = ApplyProperty.MP;
                    break;
            }
            info.applyValue = int.Parse(pa[6]);
            info.applyTime = int.Parse(pa[7]);
            info.mp = int.Parse(pa[8]);
            info.coldTime = int.Parse(pa[9]);
            switch (pa[10])
            {
                case "Swordman":
                    info.applicableRole = ApplicableRole.Swordman;
                    break;
                case "Magician":
                    info.applicableRole = ApplicableRole.Magician;
                    break;
            }
            info.level = int.Parse(pa[11]);
            switch (pa[12])
            {
                case "Self":
                    info.releaseType = ReleaseType.Self;
                    break;
                case "Enemy":
                    info.releaseType = ReleaseType.Enemy;
                    break;
                case "Position":
                    info.releaseType = ReleaseType.Position;
                    break;
            }
            info.distance = float.Parse(pa[13]);
            skillInfoDict.Add(id, info);
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//适用角色
public enum ApplicableRole
{
    Swordman,
    Magician
}
//作用类型
public enum ApplyType
{
    Passive,
    Buff,
    SingleTarget,
    MultiTarget
}
//作用属性
public enum ApplyProperty
{
    Attack,
    Def,
    Speed,
    AttackSpeed,
    HP,
    MP
}
//释放类型
public enum ReleaseType
{
    Self,
    Enemy,
    Position
}

public class SkillInfo
{
    public int id;//id
    public string name;//名称
    public string icon_name;//icon名称
    public string des;//描述Des
    public ApplyType applyType;//作用类型
    public ApplyProperty applyProperty;//作用属性
    public int applyValue;//作用值
    public int applyTime;//作用时间
    public int mp;//消耗魔法值
    public int coldTime;//冷却时间
    public ApplicableRole applicableRole;//适用角色
    public int level;//适用等级
    public ReleaseType releaseType;//释放类型
    public float distance;//释放距离
}
