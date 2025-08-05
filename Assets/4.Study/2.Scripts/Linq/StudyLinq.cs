using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class StudyLinq : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };
    private void Start()
    {
        //var result = from number in numbers
        //             select number * number; //하나씩 뽑아서 넘버 제곱하겠다는 뜻 조건X 

        var result = numbers.Select(n => n * n); //위에와 같은 내용인데 람다로 줄임       

        foreach (var n in result)        
            Debug.Log(n);
        
    }
}
