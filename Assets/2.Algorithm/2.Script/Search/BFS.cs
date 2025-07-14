using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour
{
    int[,] nodes = new int[8, 8] //�湮�� �� �ִ� ���� 1�� ���� �������� ã�ƾ���
      {
        //0,1,2,3,4,5,6,7
        { 0, 1, 1, 1, 0, 0, 0, 0}, // 0
        { 1, 0, 0, 0, 1, 1, 0, 0}, // 1
        { 1, 0, 0, 0, 0, 0, 0, 0}, // 2
        { 1, 0, 0, 0, 0, 0, 1, 0}, // 3
        { 0, 1, 0, 0, 0, 1, 0, 0}, // 4
        { 0, 1, 0, 0, 1, 0, 0, 1}, // 5
        { 0, 0, 0, 1, 0, 0, 0, 0}, // 6
        { 0, 0, 0, 0, 0, 1, 0, 0}  // 7
      };

    public Queue<int> queue = new Queue<int>();
    bool[] visited = new bool[8]; //�⺻�� false. �湮 �� ������ false

    private void Start()
    {
        DFSearch(0);
    }

    void DFSearch(int start)
    {
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int index = queue.Dequeue();

            if (!visited[index]) //�湮 �� �Ѱ��� ������
            {
                visited[index] = true; //�湮 �Ϸ�
                Debug.Log($"{index}�� ��忡 �湮");

                for (int i = 0; i < nodes.GetLength(0); i++) //
                {
                    if (nodes[index, i] == 1 && !visited[i]) //�湮�� ���� ���� 1 �� �ֵ鸸 �ִ´�                    
                        queue.Enqueue(i);
                }
            }
        }
    }
}
