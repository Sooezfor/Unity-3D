using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class DijkstraSearch : MonoBehaviour
{
    int[,] nodes = new int[6, 6]
    {
        {0,1,2,0,4,0 },
        {1,0,0,0,0,8 },
        {2,0,0,3,0,0 },
        {0,0,3,0,0,0,},
        {4,0,0,0,0,2 },
        {0,8,0,0,2,0 },
    };

    private void Start()
    {
        int start = 0;
        int[] dist; //�湮 ���� �𸣴ϱ� ���� ������ ���� 
        int[] prev;

        Dijkstra(start, out dist, out prev);

        for(int i = 0; i<nodes.GetLength(0); i++)
        {
            Debug.Log($"{start}���� {i}���� �ִ� �Ÿ� : {dist[i]}, ��� : {GetPath(i, prev)}");
        }
        
    }
    void Dijkstra(int start, out int[] dist, out int[] prev)
    {
        int n = nodes.GetLength(0); //6x6 �̴ϱ� 6.
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n]; //�湮�ߴ��� �� �ߴ���

        for(int i =0; i<n; i++)
        {
            dist[i] = int.MaxValue; //int Ÿ���� ǥ���� �� �ִ� �ִ� �����, ���Ѵ��� �����ϸ� ��. 
            prev[i] = -1; //�湮���� ���� ��� �𸣱� ������ ������ �� ���� �� -1�� ����
            visited[i] = false; //�湮���� �������� ���� �� �ʱ�ȭ
        }
        dist[start] = 0; // 0�� ��忡�� ����
        for(int count = 0; count<n; count++) //��ü ��� Ȯ�ο�
        {
            int u = -1; //�ִܰŸ� ��� 
            int min = int.MaxValue; //�ִ� �Ÿ� ����ġ

            //�湮���� ���� ��� ã�� �ִ� �Ÿ� ���� �ִ� �Ÿ� ����
            for(int j=0; j<n; j++)
            {
                if (!visited[j] && dist[j] < min)
                {
                    min = dist[j]; //�ּҰ� �ֱ�
                    u = j; //�湮�� ���� �Ҵ�
                }
            }
            if (u == -1) //�� �̻� �ִ� �Ÿ� ��� ����
                break;

            visited[u] = true;

            for(int k = 0; k<n; k++)
            {
                if (nodes[u, k] > 0 && !visited[k])
                {
                    int newDist = dist[u] + nodes[u, k]; //�� ����
                    if(newDist < dist[k])
                    {
                        dist[k] = newDist;
                        prev[k] = u;

                    }
                }                                
            }
        }
    }

    string GetPath(int end, int[] prev)
    {
        if (prev[end] == -1)
            return end.ToString();

        return $"{GetPath(prev[end], prev)} -> {end.ToString()}";
    }



}
