using System.Collections.Generic;
using UnityEngine;

public class DFS : MonoBehaviour
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

    bool[] visited = new bool[8]; //�⺻�� false. �湮 �� ������ false

    public Stack<int> stack = new Stack<int>();
    private void Start()
    {
        DFSearch(0);
    }

    void DFSearch(int start)
    {
        stack.Push(start);

        while(stack.Count > 0)
        {
            int index = stack.Pop();

            if (!visited[index]) //�湮 �� �Ѱ��� ������
            {
                visited[index] = true; //�湮 �Ϸ�
                Debug.Log($"{index}�� ��忡 �湮");

                for(int i = nodes.GetLength(0)-1; i>=0; i--) //getLength �� 8�̶� -1�� �ؼ� 7���� 0���� ������. �ε����� 7����
                {
                    if (nodes[index,i] ==1 && !visited[i]) //�湮�� ���� ���� 1 �� �ֵ鸸 �ִ´�                    
                        stack.Push(i);                    
                }
            }
        }
    }
}
