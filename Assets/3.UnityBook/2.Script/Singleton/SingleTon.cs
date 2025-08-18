using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance; //���κ���
    public static T Instance //������Ƽ
    {
        get
        {
            if (instance == null)
            {
                var t = FindFirstObjectByType<T>(); //�� ��ũ��Ʈ ���� ��ü ���� ã�ƺ���

                if (t != null) //ã�� 
                {
                    instance = t;
                }
                else //��ã��
                {
                    var newObj = new GameObject(typeof(T).ToString()); // ������Ʈ ����
                    newObj.AddComponent<T>(); //��ũ��Ʈ �߰�

                    instance = newObj.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null) //�Ҵ��ؼ� �̱���ȭ
        {
            instance = this as T; //��ӹ޴� Ÿ�� ��
            //DontDestroyOnLoad(gameObject);
        }
       //else �ߺ� ����
            //Destroy(gameObject);
    }
}
