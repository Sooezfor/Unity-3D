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
        //Debug.Log(stack.Pop()); //9 ���ð��� 
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Peek()); //�� ������ ���� ��� Ȯ�� 
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Pop());
        //Debug.Log(stack.Count);

        stack = new Stack<int>(array); //��̷� �ٲٱ� 

        list = stack.ToList(); //����Ʈ�� �ٲٱ�. �̶��� ������ ��.
        array2 = stack.ToArray(); //array�� �ٲ� ������ array2 �� �ֱ�
    }
}
