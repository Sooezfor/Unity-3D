using UnityEditor.Rendering;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    private void Start()
    {
        ShuffleFunction();
    }

    void ShuffleFunction()
    {
        for(int i=0; i< 100; i++)
        {
            int ranInt1 = Random.Range(0, array.Length); //어레이 렝스가 10이니까 9까지 될 거임. 
            int ranInt2 = Random.Range(0, array.Length); //둘 다 인덱스를 뽑는 거임.

            Swap(ranInt1, ranInt2);
        }
    }

    public void Swap(int i, int j) //인덱스가 섞이는 거고 인덱스 안에 있는 값은 그대로라는거임?
    {
        var temp = array[i]; //array[i] 인덱스가 temp 에 들어가고
        array[i] = array[j]; //array[i]에 array[j] 인덱스가 들어가고 
        array[j] = temp; // array[j]에 temp 값이 들어감. 값 스위치
    }
}
