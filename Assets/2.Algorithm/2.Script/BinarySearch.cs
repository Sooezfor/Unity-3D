using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int target = 7;

    private void Start()
    {
        int result = BSearch(); //타겟의 인덱스 값 찾기 
        Debug.Log(result);
    }

    int BSearch()
    {
        int left = 0; //초기 최소 값 
        int right = array.Length -1; //초기 맥스값

        while(left <= right)
        {            
           int mid = (left + right) / 2;
            if (array[mid] == target)
                return mid;
            else if (array[mid] < target)
            {
                left = mid + 1; //미드값보다 한 칸 앞으로 와서
            }
            else
            {
                right = mid - 1;
            }

        }
        return -1; //나오지 않는 값 넣음. 
    }
}
