using UnityEngine;

public class SingletonEx5 : MonoBehaviour
{
    private static SingletonEx5 instance; //���κ���
    public static SingletonEx5 Instance //������Ƽ
    {
        get
        {
            if(instance == null)
            {
                var obj = FindFirstObjectByType<SingletonEx5>(); //�� ��ũ��Ʈ ���� ��ü ���� ã�ƺ���

                if(obj != null) //ã�� 
                {
                    instance = obj;
                }
                else //��ã��
                {
                    var newObj = new GameObject("Singleton"); // �̱����̶�� �̸��� ������Ʈ ����
                    newObj.AddComponent<SingletonEx5>(); //��ũ��Ʈ �߰�

                    instance = newObj.GetComponent<SingletonEx5>();  
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null) //�Ҵ��ؼ� �̱���ȭ
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // �ߺ� ����
            Destroy(gameObject);
    }
}
