using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedlist1 = new LinkedList<int>();

    private void Start()
    {
        for(int i = 0; i<=10; i++)
        {
            linkedlist1.AddLast(i);
        }
        linkedlist1.AddFirst(100); //�Ǿտ�
        linkedlist1.AddLast(500);//�ǵڿ�

        var node = linkedlist1.AddFirst(1);

        linkedlist1.AddBefore(node, 200); //Ư�� ��� ���� �ִ� �� (����� �ϴ� ���� ����Ǵ� �޸�ĭ? ���� ��.)
        linkedlist1.AddAfter(node, 300); //Ư�� ����� ���Ŀ� �ִ� �� 
    }
}
