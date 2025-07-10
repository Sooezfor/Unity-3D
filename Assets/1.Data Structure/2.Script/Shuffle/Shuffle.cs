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
            int ranInt1 = Random.Range(0, array.Length); //��� ������ 10�̴ϱ� 9���� �� ����. 
            int ranInt2 = Random.Range(0, array.Length); //�� �� �ε����� �̴� ����.

            Swap(ranInt1, ranInt2);
        }
    }

    public void Swap(int i, int j) //�ε����� ���̴� �Ű� �ε��� �ȿ� �ִ� ���� �״�ζ�°���?
    {
        var temp = array[i]; //array[i] �ε����� temp �� ����
        array[i] = array[j]; //array[i]�� array[j] �ε����� ���� 
        array[j] = temp; // array[j]�� temp ���� ��. �� ����ġ
    }
}
