using UnityEngine;

public class InsertionSort : MonoBehaviour
{
    int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };
    private void Start()
    {
        Debug.Log("���� ��:" + string.Join(", ", array));

        InsertSort(array);

        Debug.Log("���� ��:" + string.Join(", ", array));
    }

    void InsertSort(int[] arr)
    {
        int n = arr.Length;

        for(int i = 0; i<n; i++)
        {
            int key = arr[i]; //i�� �������� Ű�� 
            int j = i - 1; //�� -1 �ϳĸ� ���� Ű �� �������� ������ Ȯ���� �ؾ� �ϱ� ������...�ϳ� ������ ��

            while(j>=0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
}
