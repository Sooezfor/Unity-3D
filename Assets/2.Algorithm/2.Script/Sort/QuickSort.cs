using UnityEngine;

public class QuickSort : MonoBehaviour
{
    int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };
    private void Start()
    {
        Debug.Log("정렬 전:" + string.Join(", ", array));

        Quick(array,0,array.Length-1); //배열, 0번인덱스, 마지막 인덱스?

        Debug.Log("정렬 후:" + string.Join(", ", array));
    }

    void Quick(int[] arr, int left, int right)
    {
        if(left<right)
        {
            int pivot = Partition(arr, left, right);

            Quick(arr, left, pivot - 1);
            Quick(arr, pivot + 1, right);
        }
    }
    int Partition(int[] arr, int left, int right) //피봇을 활용해서 분할
    {
        int pivot = arr[right];// 처음 피봇은 오른쪽 끝 값
        int index = left - 1; //왼쪽 끝값-1.0부터 잘 실행 안될수있어서 안전하게 -1부터 시작

        for(int i = left; i<right; i++)
        {
            if (arr[i] < pivot)
            {
                index++; //작은 수의 개수를 알려주는 인덱스

                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }
        int temp2 = arr[index + 1];
        arr[index + 1] = arr[right];
        arr[right] = temp2;

        return index + 1;
    }
}
