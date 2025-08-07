using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    //���������� predicate<�Ű�����> ������ 
    public Predicate<int> myPredicate;

    //�Ű����� 1���� ��� ���� 
    public int level = 10;

    private void Start()
    {
        myPredicate = lv => lv <= 10;
        string msg = myPredicate(level) ? "�ʺ��� ����� ���� ����" : "�ʺ��� ����� ���� �Ұ���";

        Debug.Log(msg);
    }
}
