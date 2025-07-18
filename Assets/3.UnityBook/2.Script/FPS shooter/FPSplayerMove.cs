using UnityEngine;

public class FPSplayerMove : MonoBehaviour
{
    CharacterController cc;

    public float moveSpeed = 7f;

    float gravity = -20f; //�߷°� ���� ����ؼ�
    float yVelocity = 0f;

    float jumpPower = 10f;
    bool isJumping = false; 

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v  = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized; //���⸸ �ִ� ����

        //ī�޶��� Ʈ������ �������� ������ ���� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        //transform.position += dir * moveSpeed * Time.deltaTime;

        // �߷� ����
        yVelocity += gravity * Time.deltaTime; //-������ ������ 
        dir.y = yVelocity; 

        cc.Move(dir * moveSpeed * Time.deltaTime); //ĳ���� ��Ʈ�ѷ��� ����� �̵� ���

        if (cc.collisionFlags == CollisionFlags.Below) //�Ʒ��� �����ΰ� ������
        {
            if(isJumping)            
                isJumping = false; //���ΰ� �ʱ�ȭ            
            
             yVelocity = 0f; //���� �߷°� �ʱ�ȭ
        }

        if(Input.GetButtonDown("Jump") && !isJumping) //2�� ���� ���� 
        {
            isJumping = true; 
            yVelocity = jumpPower;
        }
    }
}
