using UnityEngine;

public class SingletonEx3 : MonoBehaviour //�������� �������� ���� new ���餷 ������ 
{
    static SingletonEx3 instance = new SingletonEx3(); //���� ���� 
    public static SingletonEx3 Instance //������Ƽ
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
