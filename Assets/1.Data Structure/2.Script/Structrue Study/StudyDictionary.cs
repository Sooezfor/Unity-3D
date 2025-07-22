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
        persons.Add("Ã¶¼ö", new PersonData(35, "Ã¶¼ö", 182, 60));
        persons.Add("Àº¹Ì", new PersonData(18, "Àº¹Ì", 159, 52));
        persons.Add("±èÇõ", new PersonData(24, "±èÇõ", 178, 63));

        Debug.Log(persons["Ã¶¼ö"].age);
        Debug.Log(persons["Àº¹Ì"].age);
        Debug.Log(persons["±èÇõ"].age);
        Debug.Log(persons["Àº¹Ì"].weight);
    }
}

