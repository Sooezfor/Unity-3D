using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSplayerMove : MonoBehaviour
{
    CharacterController cc;
    Animator anim;

    public float moveSpeed = 7f;

    float gravity = -20f; //�߷°� ���� ����ؼ�
    float yVelocity = 0f;

    float jumpPower = 5f;
    bool isJumping = false;

    public int hp = 20;
    int maxHp = 20;

    public Slider hpSlider;
    public GameObject hitEffect;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float h = Input.GetAxis("Horizontal");
        float v  = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized; //���⸸ �ִ� ����

        anim.SetFloat("MoveMotion", dir.magnitude);

        //ī�޶��� Ʈ������ �������� ������ ���� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

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

    public void DamageAction(int damage)
    {
        hp -= damage;

        hpSlider.value = (float)hp / (float)maxHp; //ü�� �ǽð� ����ȭ
        
        if(hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }
    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.6f);

        hitEffect.SetActive(false);
    }
}
