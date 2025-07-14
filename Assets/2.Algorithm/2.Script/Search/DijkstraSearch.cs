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
        int[] dist; //방문 개수 모르니까 개수 정하지 않음 
        int[] prev;

        Dijkstra(start, out dist, out prev);

        for(int i = 0; i<nodes.GetLength(0); i++)
        {
            Debug.Log($"{start}에서 {i}까지 최단 거리 : {dist[i]}, 경로 : {GetPath(i, prev)}");
        }
        
    }
    void Dijkstra(int start, out int[] dist, out int[] prev)
    {
        int n = nodes.GetLength(0); //6x6 이니까 6.
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n]; //방문했는지 안 했는지

        for(int i =0; i<n; i++)
        {
            dist[i] = int.MaxValue; //int 타입이 표현할 수 있는 최대 양수값, 무한대라고 생각하면 됨. 
            prev[i] = -1; //방문하지 않은 경우 모르기 때문에 존재할 수 없는 값 -1로 설정
            visited[i] = false; //방문하지 않음으로 전부 다 초기화
        }
        dist[start] = 0; // 0번 노드에서 시작
        for(int count = 0; count<n; count++) //전체 노드 확인용
        {
            int u = -1; //최단거리 노드 
            int min = int.MaxValue; //최단 거리 가중치

            //방문하지 않은 노드 찾고 최단 거리 노드와 최단 거리 선택
            for(int j=0; j<n; j++)
            {
                if (!visited[j] && dist[j] < min)
                {
                    min = dist[j]; //최소값 넣기
                    u = j; //방문한 곳에 할당
                }
            }
            if (u == -1) //더 이상 최단 거리 노드 없음
                break;

            visited[u] = true;

            for(int k = 0; k<n; k++)
            {
                if (nodes[u, k] > 0 && !visited[k])
                {
                    int newDist = dist[u] + nodes[u, k]; //행 열값
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
