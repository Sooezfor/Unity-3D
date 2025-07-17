using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance //싱글턴 타입의 static 변수임. 
    {
        get; //접근 가능 
        private set; //수정 불가 
    }
    private void Awake()
    {
        if (Instance == null) //인스턴스가 비어있다면 자신 할당 
        {
            Instance = this;
        }
        else //또 다른 싱글턴 존재한다면 this 스크립트 삭제
            Destroy(gameObject); 
    }
}
