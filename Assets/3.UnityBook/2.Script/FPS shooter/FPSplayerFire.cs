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

    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject crosshair01;
    public GameObject crosshair02; //�� ����
    public GameObject crosshair02_zoom; //�� ȭ��

    public GameObject weapon01_R;
    public GameObject weapon02_R;

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
        Cursor.visible = false; //Ŀ�� �� ���̱�

        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.Normal;
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        #region ���콺 ���� Ŭ��


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

        #endregion

        #region ���콺 ������ Ŭ��
        if (Input.GetMouseButtonDown(1)) //���콺 ������
        {
            switch(wMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position; //��ġ�� ����

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce((Camera.main.transform.forward + Camera.main.transform.up * 0.5f) * throwPower, ForceMode.Impulse); //ī�޶� �ٶ󺸴� ���������� ������ ����ŭ)
                    break;
                case WeaponMode.Sniper:
                     ZoomMode = !ZoomMode; //������ �ݴ�. false�� true�� �ٲٰ�.                  

                     float fov = ZoomMode ? 15f : 60f;
                     Camera.main.fieldOfView = fov;

                     crosshair02_zoom.SetActive(ZoomMode);
                     crosshair02.SetActive(!ZoomMode);
                     break;                    

                    //if(ZoomMode)
                    //{
                    //    crosshair02_zoom.SetActive(true);
                    //    crosshair02.SetActive(false);

                    //}
                    //else
                    //{
                    //    crsoohair02_zoom.SetActive(false);
                    //    crosshair02.SetActive(true);

                    //}

            }
        }
        #endregion ���콺 ������ Ŭ��

        #region Ű���� 1�� Ŭ��
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Ű���� ���� ��ȣ��
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;

            wModeText.text = "Normal Mode";

            weapon01.SetActive(true);
            weapon01_R.SetActive(true);
            weapon02.SetActive(false);
            weapon02_R.SetActive(false);
            crosshair01.SetActive(true);
            crosshair02.SetActive(false);
            crosshair02_zoom.SetActive(false);
        }
        #endregion

        #region Ű���� 2�� Ŭ��
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;

            wModeText.text = "Sniper Mode";

            weapon01.SetActive(false);
            weapon01_R.SetActive(false);
            weapon02.SetActive(true);
            weapon02_R.SetActive(true);
            crosshair01.SetActive(false);
            crosshair02.SetActive(true);
            //crosshair02_zoom.SetActive(false);
        }
        #endregion
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length);
        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}
