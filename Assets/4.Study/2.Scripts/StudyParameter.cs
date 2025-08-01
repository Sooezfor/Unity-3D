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
        DefaultParameter(number); //기본값이 있어서 매개변수 안 넣어도 3으로 적용됨. 근데 값 넣으면 그 값으로 적용
        Debug.Log($"Call by Value : {number}");
        ReferenceParameter(ref number);
        Debug.Log($"Call by Reference : {number}");

        OutParameter(out number2);
        Debug.Log($"Out : {number2}");
    }

    public void NomalParaMeter(int num) //일반적인 매개변수 방법. Call by value
    {
        number = num;
    }

    //참조 방식의 매개변수. Call by Reference
    void ReferenceParameter(ref int num)
    {
        num = 10;
    }
    //선택적 매개변수(Defualt 매개변수)
    void DefaultParameter(int num = 3, float num2 = 10f)
    {
        number = num;
    }

    void OutParameter(out int num)
    {
        num = 30;
    }


       

    #region 오버로딩 

    //오버로딩 : 매개변수를 다르게 해서 다른 기능을 구현하는 방법
    void OverloadingMethod() { Debug.Log("기능 A"); }
    void OverloadingMethod(int num) { Debug.Log("기능 B"); }
    void OverloadingMethod(float num) { Debug.Log("기능 C"); }
    void OverloadingMethod(bool num) { Debug.Log("기능 D"); }
    void OverloadingMethod(int num1, int num2) { Debug.Log("기능 E"); }

    #endregion
}
