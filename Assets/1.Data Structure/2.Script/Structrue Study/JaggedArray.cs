using UnityEngine;

public class JaggedArray : MonoBehaviour //가변 배열 
{
    public int[] array1 = new int[3]; //array1 = int 값 3개
    public int[][] jaggedArray1 = new int[3][]; //int 배열이 3개

    private void Start()
    {
        array1[0] = 1;
        array1[1] = 2;
        array1[2] = 3;

        jaggedArray1[0] = new int[3] { 1, 2, 3 };
        jaggedArray1[1] = new int[4] { 1, 2, 3, 4 };
        jaggedArray1[2] = new int[5] { 1, 2, 3, 4, 5 };
    }
}
