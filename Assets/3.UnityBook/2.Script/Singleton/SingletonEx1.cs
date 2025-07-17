using UnityEngine;

public class SingletonEx1 : MonoBehaviour
{
    public static SingletonEx1 Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; //여기서 this 는 클래스 말함
        }
    }
}
