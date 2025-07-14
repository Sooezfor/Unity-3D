using System.Collections.Generic;
using UnityEngine;

public class DFS : MonoBehaviour
{
    int[,] nodes = new int[8, 8] //방문할 수 있는 곳은 1임 행을 기준으로 찾아야함
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

    bool[] visited = new bool[8]; //기본값 false. 방문 안 했으면 false

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

            if (!visited[index]) //방문 안 한곳만 들어가도록
            {
                visited[index] = true; //방문 완료
                Debug.Log($"{index}번 노드에 방문");

                for(int i = nodes.GetLength(0)-1; i>=0; i--) //getLength 가 8이라서 -1을 해서 7부터 0까지 갈거임. 인덱스는 7개라
                {
                    if (nodes[index,i] ==1 && !visited[i]) //방문한 적이 없고 1 인 애들만 넣는다                    
                        stack.Push(i);                    
                }
            }
        }
    }
}
