using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class StudyLinq2 : MonoBehaviour
{

    [Serializable] //����ȭ �����ϴٴ� �ǹ�
    public class Person
    {
        public string name;
        public int score;

        public Person(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public List<Person> persons = new List<Person>();
    public int cutline = 70;

    private void Start()
    {
        persons.Add(new Person("��", 65));
        persons.Add(new Person("���", 100));
        persons.Add(new Person("���̺��", 20));
        persons.Add(new Person("���и�", 68));
        persons.Add(new Person("����Ŭ", 89));

        CheckScore();
    }

    void CheckScore()
    {

        var passPersons = persons.Where(p => p.score >= cutline);
        var failPersons = persons.Except(passPersons); //����� ��� ������ �����

        foreach(var p in passPersons)        
            Debug.Log($"'<color=green>{p.name}</color>");

        foreach (var p in failPersons)        
            Debug.Log($"'<color=red>{p.name}</color>");

        
    }
}
