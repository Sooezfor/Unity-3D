using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    private void Start()
    {
        MethodA();
        MethodB();
    }
    void MethodA()
    {
        Debug.Log("Method A");
    }

}

public partial class StudyPartial : MonoBehaviour
{
    void MethodB()
    {
        Debug.Log("Method B");

    }
    
}

