using UnityEngine;

public class StaticArray : MonoBehaviour
{
    public int[] array1; //ũ�� ������ ���� ����Ƽ �����Ϳ��� ���� �� �� ����. 
    int[] array2 = { 10, 20, 30, 40, 50 };
    int[] array3 = new int[5]; //���� �Ҵ�
    int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; //���� �Ҵ� �� �ʱ�ȭ

    NewData[] data = new NewData[5]; 

    private void Start()
    {
        array1 = new int[5]; //�̰Ŷ� array3 �̶� ���� ��. �̷��� �� �ᵵ �����մ������� ����Ƽ �����Ϳ��� �����վ.
        int number = array2[3]; //�ε��� ���ϴ� �Ŷ� 40 �� number �� �ְڴٴ� ��.
    }
}
public class NewData
{

}