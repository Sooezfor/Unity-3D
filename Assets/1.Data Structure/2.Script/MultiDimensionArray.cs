using NUnit.Framework;
using UnityEngine;

public class MultiDimensionArray : MonoBehaviour //다차원배열
{
    public int[,] array1 = new int[3,3]; //3x3 행렬 2차원 배열의 크기 
    public int[,,] array2 = new int[3, 3, 3]; // 3차원 배열 (큐브 모양] 

    private void Start()
    {
        int number1 = array1[0, 0]; //인덱서
        int number2 = array1[1, 0];
        int number3 = array1[2, 2]; 
    }
}
