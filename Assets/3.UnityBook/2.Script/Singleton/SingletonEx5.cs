using UnityEngine;

public class SingletonEx5 : MonoBehaviour
{
    private static SingletonEx5 instance; //내부변수
    public static SingletonEx5 Instance //프로퍼티
    {
        get
        {
            if(instance == null)
            {
                var obj = FindFirstObjectByType<SingletonEx5>(); //이 스크립트 가진 객체 없나 찾아보기

                if(obj != null) //찾음 
                {
                    instance = obj;
                }
                else //못찾음
                {
                    var newObj = new GameObject("Singleton"); // 싱글톤이라는 이름의 오브젝트 생성
                    newObj.AddComponent<SingletonEx5>(); //스크립트 추가

                    instance = newObj.GetComponent<SingletonEx5>();  
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null) //할당해서 싱글톤화
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // 중복 제거
            Destroy(gameObject);
    }
}
