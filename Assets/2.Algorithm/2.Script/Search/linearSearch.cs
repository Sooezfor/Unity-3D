using UnityEngine;

public class linearSearch : MonoBehaviour
{
    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int target = 7;

    private void Start()
    {
        LinearSearch(array, target);
    }

    public void LinearSearch(int[] array, int target)
    {
        for(int i = 0; i <array.Length; i++)
        {
            if (array[i] == target)
            {
                Debug.Log($"{target}�� {i} ��°�� �ֽ��ϴ�."); //�� ���ڸ� �ε��� ������ �˷���
            }   break; 

        }
    }
}
