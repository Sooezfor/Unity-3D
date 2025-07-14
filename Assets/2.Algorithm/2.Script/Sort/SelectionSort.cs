using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    private void Start()
    {
        Debug.Log("���� ��:" + string.Join(", ", array));

        SelectSort(array);

        Debug.Log("���� ��:" + string.Join(", ", array));
    }

    void SelectSort(int[] arr)
    {
        int n = arr.Length; 

        //�ε��� �� ����
        for(int i = 0; i< n-1; i++) //i �� ������ �ε���
        {
            int minIdx = i; //������ Ư�� �ε��� �� 

            //�ڿ� �ִ� ����� �� 
            for(int j = i + 1; j<n; j++) //j; ���� �ε���
            {
                if (arr[j] < arr[minIdx])                
                    minIdx = j; //���� ������ �ٲ�                
            }
            int temp = arr[i];
            arr[i] = arr[minIdx];
            arr[minIdx] = temp; 
        }
    }
}
