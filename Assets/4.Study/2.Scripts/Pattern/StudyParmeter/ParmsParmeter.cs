using System;
using UnityEngine;

public class ParmsParmeter : MonoBehaviour
{
    private void Start()
    {
        int[] Array = new int[3] { 10, 20, 30 };
        ArrayParameter(Array);

        ParamsParameter(10, 20, 30); //���� �־ ��� ����
        
    }

    //collection �� �Ű������� ���� ���
    void ArrayParameter(int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }
    //���ڸ� ���� �־ ��� ���� 
    void ParamsParameter(params int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

}
