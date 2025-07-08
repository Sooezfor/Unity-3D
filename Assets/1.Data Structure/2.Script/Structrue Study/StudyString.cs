using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "*Hello***";
    public string[] str2 = new string[2] { "안녕", "하시긔" };

    private void Start()
    {
        //Debug.Log(str1[0]); //*가 나옴 0번째 인덱스 글자 말하는 것
        //Debug.Log(str2[0] + str2[1]); //안녕하시긔
        //Debug.Log(str1.Length); //문자열의 길이 9
        //Debug.Log(str1.Trim()); //앞뒤 공백 제거 예를 들어 " Hello, World " 이런 경우 H와 D 앞뒤 공백제거
        //Debug.Log(str1.Trim('*')); //앞 뒤 문자 중 '문자' 제거
        //Debug.Log(str1.Contains('H')); //있다면 true, 없다면 false, 대소문자도 구분함. 
        //Debug.Log(str1.ToUpper()); //다 대문자로 만들기 
        //Debug.Log(str1.ToLower()); //다 소문자로 만들기 
        //Debug.Log(str1.Replace("Hello", "Unity")); // Hello 를 Unity로 바꾸기
        //Debug.Log(str1);

        string text = "Apple,Banana, Orange,Melon,Water Melon, Mango";

        string[] fruits = text.Split(','); //특정 문자로 쪼개기 

        foreach (var fruit in fruits)
            Debug.Log(fruit); 

    }
}
