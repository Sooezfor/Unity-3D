using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int age, string name, float height, float weight)
    {
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
    }
}

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    private void Start()
    {
        persons.Add("ö��", new PersonData(35, "ö��", 182, 60));
        persons.Add("����", new PersonData(18, "����", 159, 52));
        persons.Add("����", new PersonData(24, "����", 178, 63));

        Debug.Log(persons["ö��"].age);
        Debug.Log(persons["����"].age);
        Debug.Log(persons["����"].age);
        Debug.Log(persons["����"].weight);
    }
}

