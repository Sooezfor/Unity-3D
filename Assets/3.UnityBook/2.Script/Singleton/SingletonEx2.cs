using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance //�̱��� Ÿ���� static ������. 
    {
        get; //���� ���� 
        private set; //���� �Ұ� 
    }
    private void Awake()
    {
        if (Instance == null) //�ν��Ͻ��� ����ִٸ� �ڽ� �Ҵ� 
        {
            Instance = this;
        }
        else //�� �ٸ� �̱��� �����Ѵٸ� this ��ũ��Ʈ ����
            Destroy(gameObject); 
    }
}
