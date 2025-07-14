using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };
    private void Start()
    {
        Debug.Log("���� ��:" + string.Join(", ", array));

        Bubble(array);

        Debug.Log("���� ��:" + string.Join(", ", array));
    }

    void Bubble(int[] arr)
    {
        int n = arr.Length;

        for(int i = 0; i< n-1; i++)
        {
            for(int j=0; j<n-i-1; j++)
            {
                if (arr[j] > arr[j+1])//�ڽ��� �ڿ� �ִ� �ֿ� ��
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}
