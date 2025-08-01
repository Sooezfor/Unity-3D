using System;
using UnityEngine;

public class ParmsParmeter : MonoBehaviour
{
    private void Start()
    {
        int[] Array = new int[3] { 10, 20, 30 };
        ArrayParameter(Array);

        ParamsParameter(10, 20, 30); //직접 넣어서 사용 가능
        
    }

    //collection 을 매개변수로 넣은 경우
    void ArrayParameter(int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }
    //인자를 직접 넣어서 사용 가능 
    void ParamsParameter(params int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

}
