using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public List<int> list = new List<int>();

    public int[] array = new int[3] { 1, 2, 3 };
    public int[] array2;

    private void Start()
    {
        //for(int i =1; i <=10; i++)
        //{
        //    stack.Push(i);
        //}
        //Debug.Log(stack.Pop()); //9 나올거임 
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Peek()); //그 다음에 뽑힐 대상 확인 
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Pop());
        //Debug.Log(stack.Count);

        stack = new Stack<int>(array); //어레이로 바꾸기 

        list = stack.ToList(); //리스트로 바꾸기. 이때도 역으로 들어감.
        array2 = stack.ToArray(); //array로 바꾼 스택을 array2 에 넣기
    }
}
