using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudyUnityAction : MonoBehaviour
{
    public UnityAction unityAction;
    Button button;

    private void Start()
    {
        unityAction += MethodA;

        button.onClick.AddListener(unityAction);
            
    }
    void MethodA()
    {
        Debug.Log("Method A");
    }
}
