using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "*Hello***";
    public string[] str2 = new string[2] { "�ȳ�", "�Ͻñ�" };

    private void Start()
    {
        //Debug.Log(str1[0]); //*�� ���� 0��° �ε��� ���� ���ϴ� ��
        //Debug.Log(str2[0] + str2[1]); //�ȳ��Ͻñ�
        //Debug.Log(str1.Length); //���ڿ��� ���� 9
        //Debug.Log(str1.Trim()); //�յ� ���� ���� ���� ��� " Hello, World " �̷� ��� H�� D �յ� ��������
        //Debug.Log(str1.Trim('*')); //�� �� ���� �� '����' ����
        //Debug.Log(str1.Contains('H')); //�ִٸ� true, ���ٸ� false, ��ҹ��ڵ� ������. 
        //Debug.Log(str1.ToUpper()); //�� �빮�ڷ� ����� 
        //Debug.Log(str1.ToLower()); //�� �ҹ��ڷ� ����� 
        //Debug.Log(str1.Replace("Hello", "Unity")); // Hello �� Unity�� �ٲٱ�
        //Debug.Log(str1);

        string text = "Apple,Banana, Orange,Melon,Water Melon, Mango";

        string[] fruits = text.Split(','); //Ư�� ���ڷ� �ɰ��� 

        foreach (var fruit in fruits)
            Debug.Log(fruit); 

    }
}
