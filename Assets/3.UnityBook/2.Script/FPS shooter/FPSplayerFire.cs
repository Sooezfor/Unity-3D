using System.Collections;
using TMPro;
using UnityEngine;

public class FPSplayerFire : MonoBehaviour
{
    enum WeaponMode { Normal, Sniper }
    WeaponMode wMode;

    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    private ParticleSystem ps;

    public TextMeshProUGUI wModeText;
    public GameObject[] eff_Flash;

    Animator anim;

    public float throwPower = 15f;
    public int weaponPower = 5;

    bool ZoomMode = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.Normal;
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        if (Input.GetMouseButtonDown(0)) //���콺 ���ʹ�ư 
        {
            if(anim.GetFloat("MoveMotion") == 0) //�̵����� ���� ����            
                anim.SetTrigger("Shoot");

            StartCoroutine(ShootEffectOn(0.05f));
            
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
            switch(wMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position; //��ġ�� ����

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse); //ī�޶� �ٶ󺸴� ���������� ������ ����ŭ)
                    break;
                case WeaponMode.Sniper:
                    //if (!ZoomMode)
                    //{
                    //    Camera.main.fieldOfView = 15f; //�� ���ó�� Ȯ��
                    //    ZoomMode = true;
                    //}
                    //else
                    //{
                    //    Camera.main.fieldOfView = 60f;
                    //    ZoomMode = false;
                    //} �Ʒ� 3�� �����ڷ� ���� �� ����

                    float fov = ZoomMode ? 60f : 15f;
                    Camera.main.fieldOfView = fov;
                    ZoomMode = !ZoomMode; //������ �ݴ�. false�� true�� �ٲٰ�.
                    break;                    
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)) //Ű���� ���� ��ȣ��
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;

            wModeText.text = "Normal Mode";
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;

            wModeText.text = "Sniper Mode";
        }
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length);
        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}
