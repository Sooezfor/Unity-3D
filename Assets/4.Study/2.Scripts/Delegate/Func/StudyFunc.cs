using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    //���������� + Func <�Ű�����, �Ű�����, ��ȯŸ��> ������
    public Func<int, int, int> myFunc;

    private void Start()
    {
        myFunc += AddMethod;

        int result = myFunc(10, 20);
        Debug.Log(result);
    }

    int AddMethod(int num1, int num2)
    {
        return num1 + num2;
    }
}
