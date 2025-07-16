using UnityEngine;

public class InsertionSort : MonoBehaviour
{
    int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };
    private void Start()
    {
        Debug.Log("정렬 전:" + string.Join(", ", array));

        InsertSort(array);

        Debug.Log("정렬 후:" + string.Join(", ", array));
    }

    void InsertSort(int[] arr)
    {
        int n = arr.Length;

        for(int i = 0; i<n; i++)
        {
            int key = arr[i]; //i값 기준으로 키값 
            int j = i - 1; //왜 -1 하냐면 현재 키 값 기준으로 여러번 확인을 해야 하기 때문에...하나 빼놓은 것

            while(j>=0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
}
