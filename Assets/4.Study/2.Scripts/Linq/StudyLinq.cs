using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class StudyLinq : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };
    private void Start()
    {
        //var result = from number in numbers
        //             select number * number; //�ϳ��� �̾Ƽ� �ѹ� �����ϰڴٴ� �� ����X 

        var result = numbers.Select(n => n * n); //������ ���� �����ε� ���ٷ� ����       

        foreach (var n in result)        
            Debug.Log(n);
        
    }
}
