using System;
using UnityEngine;

public class StudyFunc3 : MonoBehaviour
{
    public int hp = 100;

    public Func<int> GetHp;
    public Func<float, float> GetRemaninHp;
    public Func<string> GetAction;

    private void Start()
    {
        GetHp = () => hp; //현재 체력 
        GetRemaninHp = (dmg) => hp - dmg; //데미지 받은 후 체력

        GetAction = () =>
        {
            if (GetHp() > 50) 
                return "공격";
            else if (GetHp() > 20) // 20에서 50 사이 
                return "도망";
            else
                return "죽음";
        };
    }
}
