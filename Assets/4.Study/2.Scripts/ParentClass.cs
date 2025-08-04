using UnityEngine;

public abstract class ParentClass : MonoBehaviour
{
    public abstract void Method();
}

public class StudySealed : ParentClass
{
    public sealed override void Method()
    {
        Debug.Log("Override Method");
    }
}

public class ChildClass : StudySealed
{
    //public override void Method()
    //{
    //    //sealed 된 오버라이드 함수는 이제 더 이상 오버라이드로 수정할 수 없음.
    //}
}
