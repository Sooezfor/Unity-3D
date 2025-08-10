using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataGroup", menuName = "Scriptable Objects/WeaponDataGroup")]
public class WeaponDataGroup : ScriptableObject
{
    public WData[] wData;
   
}
[System.Serializable]
public class WData
{    
    public string name;
    public int dmg;
    public int range;
    public DetailData dData;
    public DamageSystem dSystem;
}

[System.Serializable]
public class DetailData
{
    public int cost;
    public int upgradeLv;
}
public class DamageSystem
{
    public int minDamage;
    public int maxDamage;
    public int successPrecent;
    public int criticalChance;
}
