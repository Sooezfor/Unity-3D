using UnityEngine;

public class FPSplayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    private ParticleSystem ps;

    public float throwPower = 15f;
    public int weaponPower = 5;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        if (Input.GetMouseButtonDown(0)) //마우스 왼쪽버튼 
        {
            //카메라의 앞으로 나가는 레이저
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo))
            {

                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) //맞은 대상이 에네미 레이어인 경우
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else //맞은 대상이 enemy가 아닌 경우 
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal; //총알 이펙트의 앞 방향은 노멀벡터 방향으로 

                    ps.Play();                    
                }
            }
        }

        if(Input.GetMouseButtonDown(1)) //마우스 오른쪽
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position; //위치만 설정

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse); //카메라가 바라보는 방향쪽으로 던지는 힘만큼)                
        }
    }
}
