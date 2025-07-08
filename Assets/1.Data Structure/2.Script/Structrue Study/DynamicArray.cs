using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>() { 1, 2, 3};

    private void Start()
    {
        list1.Add(10);//�������� 10�� list1�� �߰� 

        for(int i = 0; i<10; i++)// 0~9���� ���� list1�� �߰�
        {
            list1.Add(i);
        }
        list1.Insert(5,100); //5��° �ε����� 100�̶�� �� ���� 
        list1.Remove(5); //�� 5�� ����
        list1.RemoveAt(5); //�ε��� 5���� �ִ� �� ���� 
        list1.RemoveRange(1, 3); //�ε��� 1������ 3������ ���� 
        list1.Clear(); //������ ��� ����
        list1.RemoveAll(x => x >5); //��ȣ �ȿ� ���ǽ� ��. x�� ����������. Ÿ���� ����Ʈ�� Ÿ���� ����. 5���� ū ���� ����ٴٴ� ��
        list1.Sort(); //������������ 

        string str = string.Empty;
        foreach (var x in list1)
        {
            str += x.ToString() + "/";
        }
        Debug.Log(str);

        if (list1.Contains(10)) // list���� 10�̶�� ���� ������ true 
        {
            Debug.Log("�� 10�� ����");
        }
        else
            Debug.Log("�� 10�� �������� ����");
    }
}
