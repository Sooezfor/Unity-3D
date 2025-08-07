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
        GetHp = () => hp; //���� ü�� 
        GetRemaninHp = (dmg) => hp - dmg; //������ ���� �� ü��

        GetAction = () =>
        {
            if (GetHp() > 50) 
                return "����";
            else if (GetHp() > 20) // 20���� 50 ���� 
                return "����";
            else
                return "����";
        };
    }
}
