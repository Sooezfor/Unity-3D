using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int target = 7;

    private void Start()
    {
        int result = BSearch(); //Ÿ���� �ε��� �� ã�� 
        Debug.Log(result);
    }

    int BSearch()
    {
        int left = 0; //�ʱ� �ּ� �� 
        int right = array.Length -1; //�ʱ� �ƽ���

        while(left <= right)
        {            
           int mid = (left + right) / 2;
            if (array[mid] == target)
                return mid;
            else if (array[mid] < target)
            {
                left = mid + 1; //�̵尪���� �� ĭ ������ �ͼ�
            }
            else
            {
                right = mid - 1;
            }

        }
        return -1; //������ �ʴ� �� ����. 
    }
}
