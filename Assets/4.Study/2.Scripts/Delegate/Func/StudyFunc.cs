using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    //접근제한자 + Func <매개변수, 매개변수, 반환타입> 변수명
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
