using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    public int number = 1;
    public int number2;
    public int number3;

    private void Start()
    {
        NomalParaMeter(number);
        Debug.Log($"Call by Value : {number}");
        DefaultParameter(number); //�⺻���� �־ �Ű����� �� �־ 3���� �����. �ٵ� �� ������ �� ������ ����
        Debug.Log($"Call by Value : {number}");
        ReferenceParameter(ref number);
        Debug.Log($"Call by Reference : {number}");

        OutParameter(out number2);
        Debug.Log($"Out : {number2}");
    }

    public void NomalParaMeter(int num) //�Ϲ����� �Ű����� ���. Call by value
    {
        number = num;
    }

    //���� ����� �Ű�����. Call by Reference
    void ReferenceParameter(ref int num)
    {
        num = 10;
    }
    //������ �Ű�����(Defualt �Ű�����)
    void DefaultParameter(int num = 3, float num2 = 10f)
    {
        number = num;
    }

    void OutParameter(out int num)
    {
        num = 30;
    }


       

    #region �����ε� 

    //�����ε� : �Ű������� �ٸ��� �ؼ� �ٸ� ����� �����ϴ� ���
    void OverloadingMethod() { Debug.Log("��� A"); }
    void OverloadingMethod(int num) { Debug.Log("��� B"); }
    void OverloadingMethod(float num) { Debug.Log("��� C"); }
    void OverloadingMethod(bool num) { Debug.Log("��� D"); }
    void OverloadingMethod(int num1, int num2) { Debug.Log("��� E"); }

    #endregion
}
