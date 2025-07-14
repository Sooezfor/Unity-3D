using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };
    private void Start()
    {
        Debug.Log("정렬 전:" + string.Join(", ", array));

        Bubble(array);

        Debug.Log("정렬 후:" + string.Join(", ", array));
    }

    void Bubble(int[] arr)
    {
        int n = arr.Length;

        for(int i = 0; i< n-1; i++)
        {
            for(int j=0; j<n-i-1; j++)
            {
                if (arr[j] > arr[j+1])//자신의 뒤에 있는 애와 비교
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}
