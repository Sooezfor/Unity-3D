using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    public static StudySingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //���� ��ü�� �̱��� �ν��Ͻ��� ����
        }
        else
            Destroy(gameObject); //�ߺ� ���� ���� 
    }


}
