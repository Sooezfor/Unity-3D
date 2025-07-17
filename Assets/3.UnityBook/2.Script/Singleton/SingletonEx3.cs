using UnityEngine;

public class SingletonEx3 : MonoBehaviour //모노비헤비어 쓰고있을 때는 new 쓰면ㅇ ㅏㄴ됨 
{
    static SingletonEx3 instance = new SingletonEx3(); //내부 변수 
    public static SingletonEx3 Instance //프로퍼티
    {
        get
        {
            if(instance == null)
            {
                instance = new SingletonEx3();
            }
            return instance;
        }        
    }
}
