using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class StudyLinq2 : MonoBehaviour
{

    [Serializable] //직렬화 가능하다는 의미
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
        persons.Add(new Person("존", 65));
        persons.Add(new Person("사라", 100));
        persons.Add(new Person("데이비드", 20));
        persons.Add(new Person("에밀리", 68));
        persons.Add(new Person("마이클", 89));

        CheckScore();
    }

    void CheckScore()
    {

        var passPersons = persons.Where(p => p.score >= cutline);
        var failPersons = persons.Except(passPersons); //통과한 사람 제외한 사람들

        foreach(var p in passPersons)        
            Debug.Log($"'<color=green>{p.name}</color>");

        foreach (var p in failPersons)        
            Debug.Log($"'<color=red>{p.name}</color>");

        
    }
}
