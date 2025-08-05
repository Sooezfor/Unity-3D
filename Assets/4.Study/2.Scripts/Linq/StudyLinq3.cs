using UnityEngine;
using System.Linq;

public class StudyLinq3 : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    private void Start()
    {
        var result = from number in numbers
                     where number > 1
                     //orderby number // 오름차순. 기본형. 안 써도 기본으로 오름임
                     orderby number descending //내림차순. 
                     select number;

        //람다식 활용으로 내림차순
        //var result = numbers.Where(n => n > 1).OrderByDescending(n => n);

        foreach (var number in result)
            Debug.Log(number);
    }
}
