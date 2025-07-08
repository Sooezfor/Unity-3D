using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();

    private void Start()
    {
        //��ųʸ��� ������ �߰�
        persons.Add("ö��", 10);
        persons.Add("����", 35);
        persons.Add("����", 17);

        int age = persons["ö��"];
        Debug.Log($"ö���� ���̴� {age} �Դϴ�.");

        //string name = persons[17]; //�̷��� ����. �ߺ��� ����ϱ� ������ Value�� �̷��� ��ã��.
        foreach (var person in persons)
        {
            if (person.Value == 17)
                Debug.Log($"���̰� 17�� ����� �̸��� {person.Key} �Դϴ�.");

            Debug.Log($"{person.Key}�� ���̴� {person.Value}�Դϴ�.");
        }

        if(persons.ContainsKey("ö��"))
            Debug.Log("��� �߿� ö�� ����");
                
        if (persons.ContainsValue(17))
            Debug.Log("17���� ��� ����.");
    }
}

