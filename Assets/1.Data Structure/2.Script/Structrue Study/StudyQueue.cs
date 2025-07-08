using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    private void Start()
    {
        for(int i=1; i<=10; i++)
        {
            queue.Enqueue(i);//1~10까지 추가
        }
        int output = queue.Dequeue(); //값을 뽑아서 삭제
        Debug.Log(output);
        Debug.Log(queue.Peek());//그 다음에 뽑을 값 확인 

        Debug.Log(queue.Contains(5));
        queue.Clear(); //모든 값 삭제 

        Debug.Log(queue.Count); //개수확인 
    }
}
