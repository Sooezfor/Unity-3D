using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>() { 1, 2, 3};

    private void Start()
    {
        list1.Add(10);//마지막에 10을 list1에 추가 

        for(int i = 0; i<10; i++)// 0~9까지 값을 list1에 추가
        {
            list1.Add(i);
        }
        list1.Insert(5,100); //5번째 인덱서에 100이라는 값 넣음 
        list1.Remove(5); //값 5를 제거
        list1.RemoveAt(5); //인덱스 5번에 있는 값 제거 
        list1.RemoveRange(1, 3); //인덱스 1번에서 3개까지 제거 
        list1.Clear(); //데이터 모두 삭제
        list1.RemoveAll(x => x >5); //괄호 안에 조건식 들어감. x는 지역변수임. 타입은 리스트의 타입을 따라감. 5보다 큰 값을 지우겟다는 뜻
        list1.Sort(); //오름차순정렬 

        string str = string.Empty;
        foreach (var x in list1)
        {
            str += x.ToString() + "/";
        }
        Debug.Log(str);

        if (list1.Contains(10)) // list에서 10이라는 값이 있으면 true 
        {
            Debug.Log("값 10이 존재");
        }
        else
            Debug.Log("값 10이 존재하지 않음");
    }
}
