using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();

    private void Start()
    {
        //딕셔너리에 데이터 추가
        persons.Add("철수", 10);
        persons.Add("영희", 35);
        persons.Add("동수", 17);

        int age = persons["철수"];
        Debug.Log($"철수의 나이는 {age} 입니다.");

        //string name = persons[17]; //이렇게 못함. 중복을 허용하기 때문에 Value는 이렇게 못찾음.
        foreach (var person in persons)
        {
            if (person.Value == 17)
                Debug.Log($"나이가 17인 사람의 이름은 {person.Key} 입니다.");

            Debug.Log($"{person.Key}의 나이는 {person.Value}입니다.");
        }

        if(persons.ContainsKey("철수"))
            Debug.Log("사람 중에 철수 있음");
                
        if (persons.ContainsValue(17))
            Debug.Log("17살인 사람 있음.");
    }
}

