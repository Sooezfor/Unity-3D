using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    GameObject bulletFactory;
    public GameObject firePosition;

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("bullet"); //���ҽ� �������� �Ѿ� ������ �ε�
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position; //��ġ ���� 
            bullet.transform.rotation = firePosition.transform.rotation;//ȸ�� ����

            //bullet.transform.SetPositionAndRotation(��ġ,ȸ��); // ��ġ�� ȸ�� �ѹ��� �����ϴ� ��� 
            //bullet.transform.SetParent(�θ�); //�θ� ������Ʈ ���� 
        }                    
    }
}
