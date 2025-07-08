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
        linkedlist1.AddFirst(100); //맨앞에
        linkedlist1.AddLast(500);//맨뒤에

        var node = linkedlist1.AddFirst(1);

        linkedlist1.AddBefore(node, 200); //특정 노드 전에 넣는 것 (노드라고 하는 것은 연결되는 메모리칸? 같은 것.)
        linkedlist1.AddAfter(node, 300); //특정 대상의 이후에 넣는 것 
    }
}
