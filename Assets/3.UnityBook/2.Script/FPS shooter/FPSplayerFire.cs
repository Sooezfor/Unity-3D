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

        if (Input.GetMouseButtonDown(0)) //���콺 ���ʹ�ư 
        {
            //ī�޶��� ������ ������ ������
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo))
            {

                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) //���� ����� ���׹� ���̾��� ���
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else //���� ����� enemy�� �ƴ� ��� 
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal; //�Ѿ� ����Ʈ�� �� ������ ��ֺ��� �������� 

                    ps.Play();                    
                }
            }
        }

        if(Input.GetMouseButtonDown(1)) //���콺 ������
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position; //��ġ�� ����

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse); //ī�޶� �ٶ󺸴� ���������� ������ ����ŭ)                
        }
    }
}
