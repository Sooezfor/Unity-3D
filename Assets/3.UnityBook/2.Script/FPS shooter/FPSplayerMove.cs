using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSplayerMove : MonoBehaviour
{
    CharacterController cc;
    Animator anim;

    public float moveSpeed = 7f;

    float gravity = -20f; //중력값 세게 줘야해서
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
        dir = dir.normalized; //방향만 있는 벡터

        anim.SetFloat("MoveMotion", dir.magnitude);

        //카메라의 트랜스폼 기준으로 움직임 방향 변환
        dir = Camera.main.transform.TransformDirection(dir);

        // 중력 적용
        yVelocity += gravity * Time.deltaTime; //-값으로 누적됨 
        dir.y = yVelocity; 

        cc.Move(dir * moveSpeed * Time.deltaTime); //캐릭터 컨트롤러에 내장된 이동 기능

        if (cc.collisionFlags == CollisionFlags.Below) //아래에 무엇인가 닿으면
        {
            if(isJumping)            
                isJumping = false; //점핑값 초기화            
            
             yVelocity = 0f; //누적 중력값 초기화
        }

        if(Input.GetButtonDown("Jump") && !isJumping) //2단 점프 방지 
        {
            isJumping = true; 
            yVelocity = jumpPower;
        }

    }

    public void DamageAction(int damage)
    {
        hp -= damage;

        hpSlider.value = (float)hp / (float)maxHp; //체력 실시간 동기화
        
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
